 

using ApplicationDb.Entities;
 
 
using CoreCommon.DataSource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
public class UserGroupsService 
{
    private readonly BusinessDataModel _db;
    private readonly AuthorizationDataModel _context;
    private readonly INotificationsService _notifications;

    public UserGroupsService(BusinessDataModel db,AuthorizationDataModel context, INotificationsService notifications)
    {
        _db = db;
        _context = context;
        _notifications = notifications;
    }


    public List<GroupMessage> GetGroupMessages(int groupId, int page, int size)
    {
        return _context.GroupMessages.Where(m => m.GroupID == groupId).OrderByDescending(m => m.Created).Skip((page - 1) * size).Take(size).ToList();
    }


    public List<BusinessFunction> GetBusinessFunctions(int userId)
    {
        UserContext  user = _context.Users.Include(u => u.UserGroups).Where(u => u.ID == userId).SingleOrDefault();

        user.Groups = (from g in _context.Groups where (from p in user.UserGroups select p.GroupID).Contains(g.ID) select g).ToList();
        var userGroupIDs = (from p in user.Groups select p.ID).ToList();
        return (from p in _db.GroupsBusinessFunctions.Include(b => b.BusinessFunction) where userGroupIDs.Contains(p.GroupID) select p.BusinessFunction).ToList();
    }


    /// <summary>
    /// Получение списка сообщений, определённых протоколов входящей информации для бизнес функции
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    public JArray GetMessagesForBusinessFunction( BusinessFunction function )
    {
        var input = function.Input;
        if(input == null)
        {
            throw new Exception("Входящая информация назначена");
        }
        using (var db = new AuthorizationDataModel())
        {
            string tableName = input.GetInputTableName();
            var p = db.GetDatabaseManager();
            TableManager dt = (TableManager)p.fasade[tableName];
            return dt.SelectAll();
        }
            
    }



    /// <summary>
    /// Получение параметров сообщений, источником которых является пользователь 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public List<MessageProtocol> GetMessageProtocolsForUser(int userId)
    {
     
        UserContext  user = _context.Users.Include(u=>u.UserGroups).Where(u=>u.ID==userId).SingleOrDefault();
        
        user.Groups = (from g in _context.Groups where (from p in user.UserGroups select p.GroupID).Contains(g.ID) select g).ToList();
        var userGroupIDs = (from p in user.Groups select p.ID).ToList();
        var bsfs = (from p in _db.GroupsBusinessFunctions where userGroupIDs.Contains(p.GroupID) select p.BusinessFunctionID).ToList();
        var protocols = (from p in _db.MessageProtocols.Include(p=>p.Properties) where p.FromID!=null && bsfs.Contains((int)p.FromID) select p).ToList();
        return protocols.ToList();
    }

    public string GetUsername(int userId)
    {
        return (from p in _context.Users.Include(p => p.Person) where p.ID == userId select p.Person.FirstName + " " + p.Person.LastName + " " + p.Person.SurName).SingleOrDefault();
    }

    public UserGroup GetGroup(int id)
    {
        var group = _context.Groups.Find(id);
        group.People = this.GetPersons(id);

        return group;
    }

    public List<UserGroup> GetGroups()
    {
        return _context.Groups.ToList();
    }
       
    public List<UserGroup> GetUserGroups(int userId)
    {
        return _context.Groups.Where(g => (from p in _context.UserGroups where p.UserID == userId select p.GroupID).Contains(g.ID)).ToList();
    }

    public List<UserPerson> GetPersons(int groupId)
    {
        return (from u in _context.Users.Include(pu=>pu.Person) where (from p in _context.UserGroups where p.GroupID == groupId select p.UserID).Contains(u.ID) select u.Person).ToList();
    }

    public bool IsUserInGroup(int groupId, int userId)
    {
        return (from p in _context.UserGroups where p.UserID == userId && groupId == p.GroupID select p).SingleOrDefault() != null;
    }

    public void JoinToGroup(int groupId, int userId)
    {
        _context.UserGroups.Add(new UserGroups() { 
            GroupID=groupId,
            UserID = userId
        });
        _context.SaveChanges();
        _notifications.Info($"Вы добавлены в группу: {GetGroup(groupId).Name }");
        PublishIntoGroup(userId, groupId, new UserMessage()
        {
            Created = DateTime.Now,
            Subject = "Состав группы",
            Text = $"Пользователь {GetUsername(userId)} вступил в группу"
        });
    }

    public void LeaveGroup(int groupId, int userId)
    {
        _context.UserGroups.Remove((from p in _context.UserGroups where p.UserID == userId && groupId == p.GroupID select p).SingleOrDefault());
        _context.SaveChanges();
        _notifications.Info($"Вы покинули группу: {GetGroup(groupId).Name }");
            
        PublishIntoGroup(userId, groupId, new UserMessage() { 
            Created = DateTime.Now,
            Subject = "Состав группы",
            Text =    $"Пользователь {GetUsername(userId)} покинул группу"
        });
    }

    public void PublishIntoGroup(int userId, int groupId, UserMessage message)
    {
        GroupMessage newRecord = JsonConvert.DeserializeObject<GroupMessage>(JsonConvert.SerializeObject(message));
        newRecord.GroupID = groupId;
        _context.GroupMessages.Add(newRecord);
        _context.SaveChanges();
        _notifications.Info($"Вы успешно опубликовали сообщение в группе {GetGroup(groupId).Name}");
    }





        
}
 
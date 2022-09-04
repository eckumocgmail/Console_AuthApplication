



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ApplicationDb.Entities
{


    /// <summary>
    /// Обьект модели пользователя сеансов
    /// </summary>
    [Label("Пользователь")]      
    [Icon("build")]
    public class UserContext : ActiveObject
    {

        public string GetFullName()
        {
            Join("Person");
            return Person.GetFullName();
        }

        public UserContext ()
        {            
            UserGroups = new List<UserGroups>();
            Inbox = new List<UserMessage>();
            Outbox = new List<UserMessage>();
            Name = "[user]";
        }

        public UserContext (BusinessResource role, UserPerson person, UserAccount account, UserSettings settings)
        {
            UserGroups = new List<UserGroups>();     
            Role = role;
            Person = person;
            Account = account;
            Settings = settings;
            Inbox = new List<UserMessage>();
            Outbox = new List<UserMessage>();
        }
        


 
        [Label("Учетная запись")]
        public int AccountID { get; set; }

        [InputHidden(true)]
        [Label("Учетная запись")]
        public virtual UserAccount Account { get; set; }


        [Label("Роль")]
        public int BusinessResourceID { get; set; }

        [InputHidden(true)]
        [Label("Роль")]
        public virtual BusinessResource Role { get; set; }


        [Label("Настройки")]
        public int SettingsID { get; set; }
        [Label("Настройки")]
        public virtual UserSettings Settings { get; set; }
                

        [Label("Личная инф.")]
        public int PersonID { get; set; }

        [Label("Личная инф.")]
        public virtual UserPerson Person { get; set; }
 

        [NotMapped]
        [Label("Группы")]
        public virtual List<UserGroup> Groups { get; set; } = new List<UserGroup>();


        [Label("Группы")]
        [NotMapped]
        public int UserGroupsID { get; set; }

        [Label("Группы")]
        [ManyToMany("Groups")]
        [InputHidden(true)]
        public virtual List<UserGroups> UserGroups { get; set; } = new List<UserGroups>();


        [Label("Кол-во посещений")]
        public int LoginCount { get; set; }





        [Label("Входящие сообщения")]
        [InverseProperty("ToUser")]
        [NotMapped]

        public virtual List<UserMessage> Inbox { get; set; } = new List<UserMessage>();



        [Label("Исходящие сообщения")]
        [InverseProperty("FromUser")]
        [NotMapped]

        public virtual List<UserMessage> Outbox { get; set; } = new List<UserMessage>();




        [NotMapped]
        [Label("Выполняемые функции")]
        public virtual List<BusinessFunction> BusinessFunctions { get; set; } = new List<BusinessFunction>();



        public string GetHomeUrl()
        {
            return $"/{this.Role.Code}Face/{this.Role.Code}/{this.Role.Code}Home";
        }
    }

}

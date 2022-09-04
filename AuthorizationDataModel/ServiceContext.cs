using ApplicationDb.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Core.SharedData.DataModels.Authorization
{
    /// <summary>
    /// Обьект модели пользователя сеансов
    /// </summary>
    [Label("Микрослужба")]
    [Icon("build")]
    public class ServiceContext : ActiveObject
    {

        

        public ServiceContext()
        {
            ServiceGroups = new List<ServiceGroups>();
            Inbox = new List<UserMessage>();
            Outbox = new List<UserMessage>();
            Name = "[user]";
        }

        public ServiceContext(UserRole role, UserPerson person, UserAccount account, UserSettings settings)
        {
            ServiceGroups = new List<ServiceGroups>();
            BusinessResource = role;
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
        public int UserRoleID { get; set; }

        [InputHidden(true)]
        [Label("Роль")]
        public virtual UserRole BusinessResource { get; set; }


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
        //[ManyToMany("Groups")]
        [InputHidden(true)]
        public virtual List<ServiceGroups> ServiceGroups { get; set; } = new List<ServiceGroups>();


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




        //[NotMapped]
        //[Label("Выполняемые функции")]
        //public virtual List<BusinessFunction> BusinessFunctions { get; set; } = new List<BusinessFunction>();



       
    }
}

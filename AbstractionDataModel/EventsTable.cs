
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


    /// <summary>
    /// Фиксирует события бизнес процессов
    /// </summary>
    public class EventsTable: BaseEntity
    {

        [NotNullNotEmpty("Необходимо указать дату")]
        [Label("Дата регистрации")]
        [InputDateTime()]
        [NotInput()]
        public DateTime Created { get; set; } = DateTime.Now;

 
        

        public virtual int ProcessID { get; set; }
        public virtual int HostID { get; set; }
        public virtual int AppID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int ThreadID { get; set; }
        public virtual int RequestID { get; set; }


}

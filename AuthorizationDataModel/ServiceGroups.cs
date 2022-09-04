using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Core.SharedData.DataModels.Authorization
{
    [Label("Много ко многим")]
    public class ServiceGroups : BaseEntity
    {
        public int ServiceID { get; set; }

        [JsonIgnore()]
        public virtual ServiceContext Service { get; set; }
        public int GroupID { get; set; }

        [JsonIgnore()]
        public virtual UserGroup Group { get; set; }
    }
}


using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDb.Entities
{
    [Label("Много ко многим")]
    public class UserGroups: BaseEntity
    {        
        public int UserID { get; set; }

        [JsonIgnore()]
        public virtual UserContext  User { get; set; }
        public int GroupID { get; set; }

        [JsonIgnore()]
        public virtual UserGroup Group { get; set; }
    }
}


using ApplicationDb.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{
    public class UserWallet: BaseEntity
    {
        public UserWallet()
        {
            this.Markets = new List<MarketPlace>();
        }
        
        [DisplayName("Ник")]
        public string Nickname { get; set; }


        [DisplayName("Денежные средства")]
        public float? Cash { get; set; }


        public virtual IList<MarketPlace> Markets { get; set; }
    }
}

using ApplicationDb.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{
    public class MarketPlace: BaseEntity
    {
        public MarketPlace()
        {
            Subdivisions = new List<SepateSubdivision>();
        }

        public int ID { get; set; }
        public string OwnerEmail { get; set; }
        public virtual UserWallet Owner { get; set; }

        [StringLength(20, MinimumLength = 4)]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        public int LogoID { get; set; }


        [DisplayName("Фото")]
        public virtual BinaryResource Logo { get; set; }

        public virtual IList<SepateSubdivision> Subdivisions { get; set; }
    }
}

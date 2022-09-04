

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{


 
    public class SaleComposition: EventsTable
    {
 


        [DisplayName("Заказ")]
        public int SaleID { get; set; }
        public virtual SaleContract Sale { get; set; }


        [DisplayName("Продукт")]
        public int ProductID { get; set; }
        public virtual ProductDescription Product { get; set; }


        [DisplayName("Кол-во")]
        public int Count { get; set; }

        [DisplayName("Цена")]
        public float Cost { get; set; }
    }
}

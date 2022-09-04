

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{
    public class SepateSubdivision:DictionaryTable 
    {
     


        [DisplayName("Магазин")]
        public int MarketID { get; set; }
        public virtual MarketPlace Market { get; set; }


        [DisplayName("Склад")]
        public int WarehouseID { get; set; }
        public virtual Warehouse Warehouse { get; set; }



        // физический адрес тогрговой точки
        public string Location { get; set; }
        
    }
}

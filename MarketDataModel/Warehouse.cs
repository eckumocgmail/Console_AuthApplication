

using System.Collections.Generic;

namespace MvcMarketPlace.Data.Entities
{


    public class Warehouse: DictionaryTable 
    {
        public Warehouse()
        {
            ProductCountInfos = new List<ProductCountInfo>();
        }

      

        public virtual List<ProductCountInfo> ProductCountInfos { get; set; }
    }
}
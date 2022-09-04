
using ApplicationDb.Entities;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{
    public class ProductDescription : DictionaryTable
    {
        


        [DisplayName("Категория")]
        public int CategoryID { get; set; }        
        public virtual ProductCategory Category { get; set; }


        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

            
        [DisplayName("Фото")]
        public int? PhotoID { get; set; }
        public virtual BinaryResource Photo { get; set; }



    }
}

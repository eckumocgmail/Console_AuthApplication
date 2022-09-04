

using AppAnalitics.CustomerRelationModel;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppAnalitics
{
    /// <summary>
    /// Адрес подключения канала связи
    /// </summary>
    public class ConnectionAddress : DictionaryTable 
    {
      


        public string City { get; set; }        
        public string Street { get; set; }
        public string House { get; set; }
             

        
        


        /// <summary>
        /// Договор в рамках которого произведён монтаж канала связи
        /// </summary>
        public virtual SaleAgreement Agreement { get; set; }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMarketPlace.Data.Entities
{
    public class SaleContract: EventsTable
    {

      


        [DataType(DataType.Date)]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [DisplayName("Время")]
        public int Time { get; set; }


        public int CustomerID { get; set; }


 
        public int SubdivisionID { get; set; }


        [DisplayName("Подразделения")]
        public SepateSubdivision Subdivision { get; set; }


        [DisplayName("Приобретённые товары")]
        public virtual List<SaleComposition> Compositions { get; set; }


        [DisplayName("Сумма сделки")]
        public float Common { get; set; }


        [DisplayName("Идентификатор транзакции")]
        public int TransferId { get; set; }
        public MoneyTransfer Transfer { get; set; }

    }
}

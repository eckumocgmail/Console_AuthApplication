

using System;

namespace MvcMarketPlace.Data.Entities
{


    /// <summary>
    /// Операция оплаты
    /// </summary>
    public class MoneyTransfer : EventsTable
    {
 


        /// <summary>
        /// Время проведения транзакции
        /// </summary>
        public virtual DateTime Date { get; set; }


        /// <summary>
        /// Обьём финансовых средств
        /// </summary>
        public virtual float Size { get; set; }

    }
}
using System;
using System.Collections.Generic;

namespace Managment.ApiControllers.ApiControllersManagment
{
    /// <summary>
    /// Завтраты на оплату труда персоналу предприятия
    /// </summary>
    public class SalaryReport
    {
        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string Depart { get; set; }

        /// <summary>
        /// Наименование должности в штатном расписании
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Завершение периода
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Затраты в заданной единицы измерения
        /// </summary>
        public string Value { get; set; }
    }


    public class SalarySeries
    {
        public List<SalaryReport> Series { get; set; }
    }
}
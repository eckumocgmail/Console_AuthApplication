using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAnalitics.AnaliticsReportsApi
{
    public interface IHumanResourceReportsService
    {
     
        //анализ эффективности продаж в разрезе производственных показателей
        public object GetEvalHumanResourceReport(DateTime Begin);


        //анализ эффективности продаж в разрезе продуктов
        public object GetCostHumanResourceReport(DateTime Begin);


    }
}

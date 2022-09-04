using Managment.ApiControllers.ApiControllersManagment;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.ApiServices.ApiServicesManagment
{
    public interface IApiSalaryReport
    {
        SalarySeries Update(string begin, string end);
    }
    public class ApiSalaryReportService: IApiSalaryReport
    {
        private readonly ManagmentDataModel _context;

        public ApiSalaryReportService(ManagmentDataModel context)
        {
            _context = context;
        }

        public SalarySeries Update(string begin, string end)
        {

            // Создать объект подключения и команду
            SqlConnection connection = new SqlConnection(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
            var report = new SalarySeries()
            {
                Series = new List<ApiControllers.ApiControllersManagment.SalaryReport>()
            };
             
                
            connection.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand($"select * from [Managment].[GetDepatmentFond]('{begin}','{end}')",
                                                        connection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                DateTime? fromDate = ParseDate(myReader["From"].ToString());
                DateTime? toDate = ParseDate(myReader["To"].ToString());
                report.Series.Add(new ApiControllers.ApiControllersManagment.SalaryReport() { 
                    Depart = myReader["DepartmentName"].ToString(),
                    Position = myReader["PositionName"].ToString(),
                    From = fromDate,
                    To = toDate,
                    Value = myReader["Value"].ToString()
                });
            }
           
            return report;
        }


        /// <summary>
        /// Преобразование даты из формата yyyy-mm-dd
        /// </summary>
        /// <param name="sqlDateString"></param>
        /// <returns></returns>
        private DateTime? ParseDate(string sqlDateString)
        {
            return sqlDateString.ToDate();
        }
    }
}
    
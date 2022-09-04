using Managment.ApiServices.ApiServicesManagment;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


 
namespace Managment.ApiControllers.ApiControllersManagment
{
    /// <summary>
    /// CREATE FUNCTION GetPayments ( )
    /// RETURNS TABLE
    /// AS
    /// RETURN
    ///     select d.DepartmentName as DepartmentName, p.PositionName as PositionName, r.RateActivatedDate as [From], getDate() as [To], sum(r.RateSize* s.CountOfEmployees) as Value 
    ///     from Managment.Staff s
    ///     left join Managment.Position p on s.PositionID=p.ID
    ///     left join Managment.Rate r on p.ID= r.PositionID
    ///     left join Managment.Department d on d.ID= s.DepartmentID
    ///     group by d.DepartmentName, p.PositionName, r.RateActivatedDate
    /// GO
    /// </summary>
    [ApiController()]
    [Route("api/[controller]/[action]")]    
    public class SalaryReportApiController : ControllerBase, IApiSalaryReport
   
    {
        private readonly ILogger<SalaryReportApiController> _logger;
        private readonly IApiSalaryReport _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public SalaryReportApiController(
            ILogger<SalaryReportApiController> logger,
            IApiSalaryReport service)
        {
            _logger = logger;
            _service = service;
        }

   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public SalarySeries Update(string begin, string end)
        {
            _logger.LogDebug($"Update({begin},{end})");
            return _service.Update(begin, end);
        }
    }
}

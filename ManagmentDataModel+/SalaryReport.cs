
using Managment.DataModel;
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Отчёт по фонду оплаты труда, определяет объём финансовых средств,необходимый на оплату.    
/// </summary>
[Label("Фонд оплаты труда")]
public class SalaryReport : BaseEntity
{





    public OrganizationDepartment Department { get; set; }

    [SelectDictionary("Department,Name")]
    public int DepartmentID { get; set; }


    [Label("Начало периода")]
    public DateTime BeginDate { get; set; }
    public int GranularityID { get; set; }

    [Label("Фонд оплаты труда")]
    [InputNumber()]
    public float Cost { get; set; }



}
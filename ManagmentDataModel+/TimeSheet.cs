

using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Учет рабочего времени
/// </summary>
[Label("Учёт рабочего времени")]
[SearchTerms("Task,{{Employee.Name}}")]
public class TimeSheet : BaseEntity
{
    [Label("Начало периода")]
    [InputDate()]
    [NotNullNotEmpty()]
    public DateTime BeginTime { get; set; }

    [Label("Конеч периода")]
    [InputDate()]
    [NotNullNotEmpty()]
    public DateTime EndTime { get; set; }

    [Label("Сотрудник")]
    [SelectDataDictionary("Employee,SurName")]
    public int EmployeeID { get; set; }
    public virtual Employee Employee { get; set; }

    [Label("Задача")]
    [InputText()]
    public string Task { get; set; }

}
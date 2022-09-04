
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.ComponentModel.DataAnnotations.Schema;


[Label("Опыт работы сотрудника")]
[SearchTerms("{{Skill.Name}},{{Employee.Name}}")]
public class EmployeeExpirience : EventsTable
{

    [Label("Сотрудник")]
    [SelectDataDictionary("Employee,FirstName")]
    public int EmployeeID { get; set; }


    public virtual Employee Employee { get; set; }



    [Label("Навык")]
    [SelectDataDictionary("Skill,Name")]
    public int SkillID { get; set; }


    public virtual SKillExpirience Skill { get; set; }


    [Column(TypeName = "date")]
    [Label("Дата")]
    [NotNullNotEmpty("Дата не может принимать нулевое значение")]
    [InputDate()]
    public DateTime Begin { get; set; }

    [Label("Периодичность")]
    [InputNumber()]
    [NotNullNotEmpty("Периодичность не может иметь нулевое значение")]
    public int Granularity { get; set; }
}


using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Даталогическая модель сущноcти "Штатное расписание".
/// </summary>
 
[Label("Штатное расписание")]
[SearchTerms("Department.Name,Position.Name")]
public class StaffsTable : BaseEntity
{


    /// <summary>
    /// Внешний ключ к "Подразделению"
    /// </summary>
    [Label("Подразделение")]
    [SelectDataDictionary("Department,Name")]
    public int DepartmentID { get; set; }

    /// <summary>
    /// Ссылка на "Подразделение"
    /// </summary>       
    [Navigation("DepartmentID")]
    public virtual  OrganizationDepartment Department { get; set; }

    /// <summary>
    /// Внешний ключ к "Должности" 
    /// </summary>
    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; }

    /// <summary>
    /// Ссылка на "Должность"
    /// </summary>
    [Navigation("PositionID")]
    public virtual EmployeePosition Position { get; set; }

    /// <summary>
    /// Дата, начиная с которой данные являются действительными
    /// </summary>
    [Column(TypeName = "Date")]
    [Label("Дата")]
    [InputDate()]
    public DateTime StaffActivatedDate { get; set; } = DateTime.Now;


    /// <summary>
    /// Кол-во сотрудников в штате подразделения
    /// </summary>
    [Label("Кол-во штатных единиц")]
    [InputNumber()]
    [IsPositiveNumber("Значение должно принадлежать множеству натуральных чисел")]
    public int CountOfEmployees { get; set; }
}
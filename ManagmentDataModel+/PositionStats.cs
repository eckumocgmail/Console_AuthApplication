using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Даталогическая модель сущности "Ставка".
/// </summary>
 
[Label("Тарифная ставка")]
[SearchTerms("{{Position.Name}}")]
public class PositionStats : BaseEntity
{

    /// <summary>
    /// Внешний ключ к "Должности"
    /// </summary>
    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; }

    /// <summary>
    /// Ссылка на "Должность"
    /// </summary>
    public virtual EmployeePosition Position { get; set; }

    /// <summary>
    /// Дата, начиная с которой данные являются действительными
    /// </summary>
    [Column(TypeName = "Date")]
    [Label("Дата")]
    [InputDate()]
    public DateTime RateActivatedDate { get; set; }

    /// <summary>
    /// Объём финансовых средств на штатную единицу
    /// </summary>

    [InputNumber()]
    [Label("Объём финансовых средств на штатную единицу")]
    public double RateSize { get; set; }
}
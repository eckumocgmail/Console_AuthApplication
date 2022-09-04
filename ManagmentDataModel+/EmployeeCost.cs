







using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreModel.Attributes.AttributeEntity { }


[Label("Коэффициенты трудового стажа")]
[SearchTerms(nameof(Name) + "," + nameof(Description) + "," + "{{Position.Name}}")]
public class EmployeeCost : DictionaryTable 
{

    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; }

    [Navigation("PositionID")]
    public virtual EmployeePosition Position { get; set; }


    [Label("Коэффициент ставки")]
    [InputNumber()]
    [IsPositiveNumber("Значение должно быть больше нуля")]
    public float Param { get; set; }
}
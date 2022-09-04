



using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System.Collections.Generic;
/// <summary>
/// Должностные обязанности
/// </summary>
[Label("Должностные обязанности")]
[SearchTerms(nameof(Name) + ",Description,{{Position.Name}}")]
public class PositionFunction : DictionaryTable 
{

    public PositionFunction()
    {
        FunctionSkills = new List<FunctionSkills>();
    }

    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; }

    public virtual EmployeePosition Position { get; set; }

    public virtual List<FunctionSkills> FunctionSkills { get; set; }



}
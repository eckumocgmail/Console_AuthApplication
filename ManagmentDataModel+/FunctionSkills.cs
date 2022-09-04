

using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;

/// <summary>
/// Навыки необходимые для выполнения должностной функции
/// </summary>
[Label("Функциональная обязанность")]
[SearchTerms("Description,{{Skill.Name}},{{Position.Name}}")]
public class FunctionSkills : BaseEntity
{

    [Label("Должностная функция")]
    [SelectDataDictionary("PositionFunction,Name")]
    public int PositionFunctionID { get; set; }
    public virtual PositionFunction PositionFunction { get; set; }

    [Label("Профессиональный навык")]
    [SelectDataDictionary("Skill,Name")]
    public int SkillID { get; set; }
    public virtual SKillExpirience Skill { get; set; }


}
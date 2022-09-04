[Label("Этап лечения")]
[ClassDescription("")]
public class MedicalStep : BaseEntity
{

    [Label("Случай СМО")]
    public int MedicalCaseID { get; set; }

    [Label("Случай СМО")]
    public virtual MedicalCase MedicalCase { get; set; }


    [Label("Тип")]
    //[SelectControl("Стационарая,амбулаторная,др.")]
    public string MedicalEnv { get; set; }

    [Label("Форма")]
    //[SelectControl("Неотложная,экстренная,плановая")]
    public string MedicalForm { get; set; }


    [Label("Мед. услуга")]
    public int MedicalFunctionID { get; set; }
    public virtual MedicalFunction MedicalFunction { get; set; }

    [Label("Документ")]
    [NotNullNotEmpty("Необходимо зарегистрировать документ")]
    [InputXml()]
    public string MedicalDocument { get; set; }

}
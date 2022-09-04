using System.Collections.Generic;

[Label("Медицинская организация")]
public class MedicalOrganization: ManagmentOrganization 
{
    [Label("Медицинские карточки")]
    public virtual List<MedicalCard> MedicalCards { get; set; }


    [Label("Медицинские услуги")]
    public virtual List<BusinessFunction> MedicalFunctions { get; set; }
}
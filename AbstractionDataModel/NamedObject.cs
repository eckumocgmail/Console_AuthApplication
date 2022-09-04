using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
 
//[SearchTerms("Name,Description")]     
public class NamedObject: BaseEntity 
{
    [Label("Наименование")]
    [NotNullNotEmpty("Необходимо указать наименование")]
    //[UniqValidation("Имя должно иметь уникальное значение")]
   // [RusText("Используйте русский имена")]
    [InputText()]
    public virtual string Name { get; set; }

    [Label("Описание")]
    [NotNullNotEmpty("Необходимо указать описание")]
    [InputMultilineText()]
    public virtual string Description { get; set; }
    
    [NotMapped]
    [InputHidden(true)]
    [JsonIgnore()]
    public object Item { get; set; }


    public NamedObject()
    {
        Name = Description = "";
    }

}
 
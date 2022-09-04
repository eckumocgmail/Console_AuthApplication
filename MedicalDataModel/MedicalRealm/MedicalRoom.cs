

[Label("Помещение")]
public class MedicalRoom : DictionaryTable 
{
    [Label("Этаж")]
    [NotNullNotEmpty("Необходимо указать этаж")]
    public int Floor { get; set; } = 1;
}
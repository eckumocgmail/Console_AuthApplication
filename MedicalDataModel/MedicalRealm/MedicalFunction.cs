using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Медицинская услуга")]
public class MedicalFunction : BaseEntity
{

    [Label("Наменование мед. услуги")]
    [NotNullNotEmpty("Укажите тип мед. услуги")]
    [RusText()]
    public string Name { get; set; }

    [Label("Выплата согласно тарифу")]
    [NotNullNotEmpty("Укажите тип мед. услуги")]
    [IsPositiveNumber( )]
    [InputNumber()]
    public float Tarriff { get; set; }


    //[SelectControl("Консультация,первичное посещение,диагностическое исследование,лабораторное исследование")]
    public string Type { get; set; }



}
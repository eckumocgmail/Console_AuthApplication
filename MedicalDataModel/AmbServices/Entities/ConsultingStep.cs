using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Label("Консультация врача специалиста")]
[Description("Для постановки точного диагноза терапевт направляет на консультации к врача специалистам узкого профиля.")]
public class ConsultingStep: MedicalStep
{

    [Label("Дата получения консультации")]
    public DateTime Date { get; set; }


    [SelectDataDictionary("ConsultingTariffs")]
    public int TariffId { get; set; }
    
}

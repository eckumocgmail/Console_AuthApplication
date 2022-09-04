using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Медицинская койка")]
public class MedicalBed : BaseEntity
{
    [Label("Пациент")]    
    public virtual MedicalCard MedicalTarget {get;set;}



    public virtual List<MedicalDevice> MedicalDevices { get; set; }
}
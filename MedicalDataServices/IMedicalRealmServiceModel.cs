using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMedicalRealmServiceModel  
{
    public IEntityFasade<MedicalCard> MedicalCards { get; set; }
    public IEntityFasade<MedicalStep> MedicalSteps { get; set; }
    public IEntityFasade<MedicalCase> MedicalCases { get; set; }
    public IEntityFasade<EmployeePosition> ManagmentPositions { get; set; }
    public IEntityFasade<MedicalBed> MedicalBeds { get; set; }
    public IEntityFasade<MedicalDevice> MedicalDevices { get; set; }
    public IEntityFasade<MedicalFunction> MedicalFunctions { get; set; }
    public IEntityFasade<MedicalLab> MedicalLabs { get; set; }
    public IEntityFasade<MedicalRoom> MedicalRoom { get; set; }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMedicalRealmModel
{
    /// <summary>
    /// Medical
    /// </summary>      
    /// 
    public DbSet<EmployeePosition> ManagmentPositions { get; set; }


    public DbSet<MedicalBed> MedicalBeds { get; set; }
    public DbSet<MedicalDevice> MedicalDevices { get; set; }
    public DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public DbSet<MedicalLab> MedicalLabs { get; set; }
    public DbSet<MedicalRoom> MedicalRoom { get; set; }
}
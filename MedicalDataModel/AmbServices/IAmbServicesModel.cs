using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAmbServicesModel   
{
    public DbSet<ConsultingStep> ConsultingSteps { get; set; }
    public DbSet<DiagnosticReport> DiagnosticReport { get; set; }
    public DbSet<DiagnosticsStep> DiagnosticsSteps { get; set; }
    
    public DbSet<LabReport> LabReports { get; set; }
    public DbSet<OperationStep> OperationSteps { get; set; }
}
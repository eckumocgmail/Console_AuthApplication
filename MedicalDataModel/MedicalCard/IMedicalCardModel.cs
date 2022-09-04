using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMedicalCardModel: IDbContext
{
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<MedicalStep> MedicalSteps { get; set; }
    public DbSet<MedicalCase> MedicalCases { get; set; }
}

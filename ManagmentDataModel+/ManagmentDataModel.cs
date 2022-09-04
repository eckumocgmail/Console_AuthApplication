using ApplicationCore.Converter;
using ApplicationCore.Converter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ManagmentDataModel : DbContext, IDbContext, IManagmentModel
{

    public List<string> GetPendingMigrations()
    {
        return (List<string>)Database.GetPendingMigrations();
    }



    public List<string> GetMigrations()
    {

        return (List<string>)Database.GetAppliedMigrations();
    }
    public IEnumerable<INavigation> GetNavFor(Type type)
    {
        return ((DbContext)this).GetNavigationPropertiesForType(type);
    }

    public List<string> GetEntityTypeNames()
    {
        return this.GetEntitiesTypes().Select(t => Typing.ParseCollectionType(t)).ToList();
    }

    void IDbContext.SaveChanges()
    {
        base.SaveChanges();
    }

    public void Update(BaseEntity baseEntity)
    {
        base.Update(baseEntity);
    }
    public ManagmentDataModel() { }
    public ManagmentDataModel(DbContextOptions<ManagmentDataModel> options) : base(options)
    {

    }


    /// <summary>
    /// Создание структуры данных
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        //uniq constraint
        builder.Entity< OrganizationDepartment>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<EmployeePosition>()
               .HasIndex(u => u.Name)
               .IsUnique();


        //uniq constraint
        builder.Entity<Employee>()
               .HasIndex(u => new { u.FirstName, u.SurName, u.LastName, u.Birthday })
               .IsUnique();


        //uniq constraint
        builder.Entity<EmployeeExpirience>()
               .HasIndex(u => new { u.EmployeeID, u.SkillID, u.Begin })
               .IsUnique();


        //uniq constraint
        builder.Entity<PositionStats>()
               .HasIndex(u => new { u.RateActivatedDate, u.PositionID })
               .IsUnique();

        //uniq constraint
        builder.Entity<SKillExpirience>()
               .HasIndex(u => new { u.Name })
               .IsUnique();



        //uniq constraint
        builder.Entity<StaffsTable>()
               .HasIndex(u => new { u.DepartmentID, u.PositionID, u.StaffActivatedDate })
               .IsUnique();



        //uniq constraint
        builder.Entity<EmployeeCost>()
               .HasIndex(u => new { u.PositionID })
               .IsUnique();


        //uniq constraint
        builder.Entity<TimeSheet>()
               .HasIndex(u => new { u.BeginTime, u.EndTime, u.EmployeeID })
               .IsUnique();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
            optionsBuilder.UseInMemoryDatabase(GetType().Name);
            
            /*optionsBuilder.UseSqlServer(
                @"Server=KEST;Database=" + nameof(AuthorizationDataModel) +
                @";Trusted_Connection=True;MultipleActiveResultSets=true;"
            );*/
    }



     
    public DbSet<ManagmentOrganization> Organizations { get; set; }
    public DbSet< OrganizationDepartment> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }
    public DbSet<PositionStats> PositionStats { get; set; }
    public DbSet<EmployeePosition> Positions { get; set; }
    public DbSet<PositionFunction> PositionFunctions { get; set; }
    public DbSet<FunctionSkills> FunctionSkills { get; set; }
    //public DbSet<SalaryReport> SalaryReports { get; set; }
    public DbSet<SKillExpirience> Skills { get; set; }
    public DbSet<StaffsTable> Staffs { get; set; }
    public DbSet<EmployeeCost> TariffRates { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
    public DbSet<ManagmentLocation> Locations { get; set; }
    //public DbSet<SalaryReport> SalaryReports { get; set; }
}
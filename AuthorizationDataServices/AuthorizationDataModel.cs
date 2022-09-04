using ApplicationCommon.CommonResources;

using ApplicationCore.Converter;

using ApplicationDb.Entities;

using AppModel.Model.BankDataModel;

using Managment.DataModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

using NetCoreConstructorAngular.Controllers;
using NetCoreConstructorAngular.Data;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Контекст доступа к обьектам базы данных (EntityFramework)
/// </summary>
public partial class AuthorizationDataModel : DbContext, IDbContext, IManagmentModel
{

    public IEnumerable<INavigation> GetNavFor(Type type)
    {
        if(type==null)
        {
            int x = 0;
        }
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


    /// <summary>
    /// Строка соединения ADO.NET с сервером баз данных SQL Server
    /// </summary>
    public static string DEFAULT_CONNECTION_STRING =
                            @"Server=AGENT;" +
                            @"Database=AppDesign;" +
                            @"User ID=sa;" +
                            @"PWD=Gye*34FRtw;" +
                            
                            @"MultipleActiveResultSets=true;";

    public virtual DbSet<UserAccount> Accounts { get; set; }
    public virtual DbSet<UserContext> Users { get; set; }
 
    
    public virtual DbSet<LoginEvents> LoginEvents { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }
    public virtual DbSet<GroupMessage> GroupMessages { get; set; }
    public virtual DbSet<UserGroup> Groups { get; set; }
    public virtual DbSet<UserMessage> Messages { get; set; }
    public virtual DbSet<UserPerson> Persons { get; set; }
    public virtual DbSet<UserSettings> Settings { get; set; }
  //  public virtual DbSet<BusinessResource> Roles { get; set; }


    public virtual DbSet<CurrencyUnit> CurrencyUnits { get; set; }
    public virtual DbSet<PersonWallet> PersonWallets { get; set; }
    public virtual DbSet<OrgWallet> OrgWallets { get; set; }
   
    /// <summary>
    /// 
    /// </summary>
   
   /* public virtual DbSet<MessageAttribute> MessageAttributes { get; set; }
    public virtual DbSet<MessageProperty> MessageProperties { get; set; }
    public virtual DbSet<MessageProtocol> MessageProtocols { get; set; }
    public virtual DbSet<ImageResource> ImageResources { get; set; }
 
    */


   // public virtual DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    public virtual DbSet<BusinessLogic> BusinessLogics { get; set; }
    public virtual DbSet<BusinessDataset> BusinessDatasets { get; set; }
    public virtual DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public virtual DbSet<BusinessDatasource> BusinessDatasources { get; set; }
 
    public DbSet<BusinessProcess> BusinessProcesss { get; set; }
    public DbSet<BusinessReport> BusinessReports { get; set; }
    public DbSet<BusinessResource> BusinessResources { get; set; }
    public DbSet<BusinessProcess> BusinessProcesses { get; set; }
 
    public DbSet<ValidationModel> ValidationModels { get; set; }
    public DbSet<BusinessData> BusinessOLAP { get; set; }
    public DbSet<BusinessIndicator> BusinessIndicators { get; set; } 
    public DbSet<BusinessGranularities> Granularities { get; set; }
    public DbSet<BusinessData> BusinessData { get; set; }
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileResource> FileResources { get; set; }

   
  

    public AuthorizationDataModel()
    {

    }
    public AuthorizationDataModel(DbContextOptions<AuthorizationDataModel> options) : base(options)
    {

    }

    public void ExecuteProcedure(string sql)
    {
        throw new Exception(sql);
        //Database.ExecuteSqlCommand(string.Format(
        //                @"CREATE UNIQUE INDEX LX_{0} ON {0} ({1})",
        //                         "Entitys", "FirstColumn, SecondColumn"));
    }


    public void GetProcedures()
    {
        foreach (var fx in Model.GetDbFunctions())
        {
   
            string query = fx.Name;
            foreach (var par in fx.Parameters)
            {
                query += $"{par.Name} {par.TypeMapping.DbType.Value} ";
            }
            Writing.ToConsole(query);
            
        }
    }

    


    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="v">текст сообщения</param>
    private void ToConsole(string v)
    {
        Debug.WriteLine(v);
    }


     

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(ApplicationDbContext));
            //optionsBuilder.UseSqlServer(DEFAULT_CONNECTION_STRI
            //NG);
            //optionsBuilder.ConfigureWarnings(ConfigureWarnings);            
            //optionsBuilder.EnableDetailedErrors(true);           
            //optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
        }
    }

    private void ConfigureWarnings(WarningsConfigurationBuilder obj)
    {
                
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //uniq constraint
        builder.Entity<BusinessResource>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<BusinessResource>()
               .HasIndex(u => u.Code)
               .IsUnique();

        //uniq constraint
        builder.Entity<UserAccount>()
               .HasIndex(u => u.Email)
               .IsUnique();


        //uniq constraint
        builder.Entity<UserGroup>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<UserGroups>()
               .HasIndex(u => new { u.UserID, u.GroupID })
               .IsUnique();

        //uniq constraint
        builder.Entity<UserPerson>()
               .HasIndex(u => new { u.FirstName, u.SurName, u.LastName, u.Birthday })
               .IsUnique();
    }

    public DbSet<ManagmentOrganization> Organizations { get; set; }
    public DbSet<OrganizationDepartment> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }
    public DbSet<EmployeePosition> Positions { get; set; }
    public DbSet<PositionFunction> PositionFunctions { get; set; }
    public DbSet<FunctionSkills> FunctionSkills { get; set; }
    public DbSet<SKillExpirience> Skills { get; set; }
    public DbSet<StaffsTable> Staffs { get; set; }
    public DbSet<EmployeeCost> TariffRates { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
    public DbSet<ManagmentLocation> Locations { get; set; }
    public DbSet<SalaryReport> SalaryReports { get; set; }
}
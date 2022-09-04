using ApplicationCommon.CommonResources;

using ApplicationCore.Converter;

using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

using MvcMarketPlace.Data.Entities;
using NetCoreConstructorAngular.Controllers;
using NetCoreConstructorAngular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

[Label("Модель интернет-магазина")]
[Description("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
public class MedicalDataModel :   DbContext, IDbContext
{

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
    public MedicalDataModel() : base() { }
    public MedicalDataModel(DbContextOptions<MedicalDataModel> options) : base(options) { }


    public virtual DbSet<MedicalOrganization> MedOrganizations { get; set; }
    public virtual DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public virtual DbSet<MedicalCard> MedicalCards { get; set; }
    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
    public virtual DbSet<HospitalDepartment> HospitalDepartments { get; set; }    
    public virtual DbSet<MedicalDepartment> MedicalDepartments { get; set; }
    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    



    public virtual DbSet<UserAccount> Accounts { get; set; }
    public virtual DbSet< UserContext > Users { get; set; }

    public virtual DbSet<LoginEvents> LoginFacts { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }
    public virtual DbSet<UserGroup> Groups { get; set; }
    public virtual DbSet<UserMessage> Messages { get; set; }
    public virtual DbSet<UserPerson> Persons { get; set; }
    public virtual DbSet<UserSettings> Settings { get; set; }
    public virtual DbSet<BusinessResource> BusinessResources { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<GroupMessage> GroupMessages { get; set; }
    public virtual DbSet<MessageAttribute> MessageAttributes { get; set; }
    public virtual DbSet<MessageProperty> MessageProperties { get; set; }
    public virtual DbSet<MessageProtocol> MessageProtocols { get; set; }
    public virtual DbSet<ImageResource> ImageResources { get; set; }




    public virtual DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    public virtual DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public virtual DbSet<BusinessDatasource> BusinessDatasources { get; set; }
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileResource> FileResources { get; set; }

    /// <summary>
    /// Выполняется по событию установки конфигурации в EntityFramework
    /// </summary>
    /// <param name="builder">объект содержит методы конфигурации</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(ApplicationDbContext));
            //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING.Replace("AppDesign", "MedicalApp"));
            //optionsBuilder.ConfigureWarnings(ConfigureWarnings);
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
        }

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }





}
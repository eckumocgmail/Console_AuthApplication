using ApplicationCore.Converter;

using EnterpriceResourcePlanin;
 

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

using MvcMarketPlace.Data.Entities;

using NetCoreConstructorAngular.Data;

using System;
using System.Collections.Generic;
using System.Linq;

[Label("Модель интернет-магазина")]
[Description("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
public class MarketDataModel: DbContext, IDbContext
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
    public MarketDataModel() : base() { }
    public MarketDataModel(DbContextOptions<MarketDataModel> options) : base(options) { }


    public virtual DbSet<MarketPlace> MarketPlaces { get; set; }
    public virtual DbSet<MoneyTransfer> MoneyTransfers { get; set; }
    public virtual DbSet<PriceList> PriceLists { get; set; }
    public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
    public virtual DbSet<ProductCountInfo> ProductCountInfos { get; set; }
    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
    public virtual DbSet<ProductionDealer> ProductionDealers { get; set; }
    public virtual DbSet<SaleComposition> SaleCompositions { get; set; }    
    public virtual DbSet<SaleContract> SaleContracts { get; set; }
    public virtual DbSet<UserWallet> UserWallets { get; set; }   
    public virtual DbSet<Warehouse> Warehouses { get; set; }
    public virtual DbSet<SepateSubdivision> SepateSubdivisions { get; set; }



    /// <summary>
    /// Выполняется по событию установки конфигурации в EntityFramework
    /// </summary>
    /// <param name="builder">объект содержит методы конфигурации</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(ApplicationDbContext));
            //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
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
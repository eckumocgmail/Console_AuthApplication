using ApplicationCommon.CommonResources;

using ApplicationCore.Converter;

using ApplicationDb.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public interface IResourseDataModel
{
    public DbSet<FileCatalog> FileCatalogs { get; set; }
    public DbSet<FileResource> FilResources { get; set; }
    public DbSet<ImageResource> Photos { get; set; }
    public DbSet<Resource> Resources { get; set; }
}


public class ResourcesDataModel: DbContext, IDbContext, IResourseDataModel
{
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileResource> FilResources { get; set; }
    public virtual DbSet<ImageResource> Photos { get; set; }
    public virtual DbSet<Resource> Resources { get; set; }


    public ResourcesDataModel() { }
    public ResourcesDataModel(DbContextOptions<AuthorizationDataModel> options) : base(options)
    {

    }


    /// <summary>
    /// Создание структуры данных
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

 

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
            optionsBuilder.UseInMemoryDatabase(GetType().Name); 
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
}
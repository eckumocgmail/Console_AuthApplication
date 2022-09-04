

using ApplicationCore.Converter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAnalitics
{


    /// <summary>
    /// Моде
    /// </summary>
    public class CommunicationDataModel : DbContext, IDbContext
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

        public virtual DbSet<AnalogTransmission> AnalogTransmissions { get; set; }
        public virtual DbSet<LocalChanals> LocalChanalss { get; set; }
        public virtual DbSet<AnalogTransmission> MagistralChanal { get; set; }
        public virtual DbSet<MediaTransmission> MediaTransmissions { get; set; }
        public virtual DbSet<OpticalTransmission> OpticalTransmissions { get; set; }

        public virtual DbSet<RadioTansmission> RadioTansmissions { get; set; }
        public virtual DbSet<ZoneChanals> ZoneChanals { get; set; }

        public CommunicationDataModel() : base() {
          

        }
        public CommunicationDataModel(DbContextOptions<CommunicationDataModel> options) : base(options) { }

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
            
            }

        }

     
    }
}

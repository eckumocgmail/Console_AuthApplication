using ApplicationCore.Converter;

using AppAnalitics.CustomerRelationModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

using NetCoreConstructorAngular.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlanin
{


    /*******
     * 
     * 
     * Система управления взаимоотношениями с клиентами (CRM, CRM-система, сокращение от англ. Customer Relationship Management) — 
     * прикладное программное обеспечение для организаций, предназначенное для автоматизации стратегий взаимодействия с заказчиками (клиентами), 
     * в частности для повышения уровня продаж, оптимизации маркетинга и у
     * лучшения обслуживания клиентов путём сохранения информации о клиентах 
     * и истории взаимоотношений с ними, установления и улучшения бизнес-процессов и последующего анализа результатов.

    CRM — модель взаимодействия, основанная на теории, что центром всей философии бизнеса является клиент,
    а главными направлениями деятельности компании являются меры 
    по обеспечению эффективного маркетинга, продаж и обслуживания клиентов. 
    
    Поддержка этих бизнес-целей включает сбор, хранение и анализ информации о потребителях, поставщиках, партнёрах, 
    а также о внутренних процессах компании. 
    
    Функции для поддержки этих бизнес-целей включают продажи, маркетинг, поддержку потребителей. 
    

    (**)
     веб-страницы для отслеживания клиентами состояния заказа,
                уведомление по SMS о событиях, связанных с заказом или лицевым счётом, 
                возможность для клиента самостоятельно выбрать и заказать в режиме реального 
                времени продукты и услуги, а также другие интерактивные возможности).
     
     
     
     */




    public class CustomerDataModel:  DbContext, IDbContext
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

    public virtual DbSet<AgreementConnectonLocation> Agreements { get; set; }
        public virtual DbSet<CustomerInfo> CustomersInfo { get; set; }
        public virtual DbSet<MediaService> MediaServices { get; set; }
        public virtual DbSet<InternetService> InternetServices { get; set; }
        public virtual DbSet<SizeLimitTarrification> SizeLimitTarrifications { get; set; }
        public virtual DbSet<TimeLimitTarrification> TImeLimitTarrifications { get; set; }


        

        public CustomerDataModel() : base() {
            Database.EnsureCreated();
        }
        public CustomerDataModel(DbContextOptions<CustomerDataModel> options) : base(options) 
        {
            Database.EnsureCreated();
        }





        



        /// <summary>
        /// Выполняется по событию установки конфигурации в EntityFramework
        /// </summary>
        /// <param name="builder">объект содержит методы конфигурации</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Writing.ToConsole(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(nameof(ApplicationDbContext));
                //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
                //optionsBuilder.ConfigureWarnings(ConfigureWarnings);
                optionsBuilder.EnableDetailedErrors(true);
                optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

 
        }


    }
}

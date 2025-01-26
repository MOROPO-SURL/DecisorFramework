using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorInventoryPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Warehouse, System.Guid>, WarehouseRepository>();
            services.AddScoped<IEntityRepository<Batch, System.Guid>, BatchRepository>();
            services.AddScoped<IEntityRepository<Product, System.Guid>, ProductRepository>();
            services.AddScoped<IEntityRepository<Category, int>, CategoryRepository>();
            services.AddScoped<IEntityRepository<Classification, System.Guid>, ClassificationRepository>();
            services.AddScoped<IEntityRepository<UnitMeasurement, System.Guid>, UnitMeasurementRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.InventoryDbSchemaConfigurationProvider>();
        }
    }
}


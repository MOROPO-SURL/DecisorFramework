using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorPurchasingPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<PurchaseRequest, System.Guid>, PurchaseRequestRepository>();
            services.AddScoped<IEntityRepository<PurchaseOrder, System.Guid>, PurchaseOrderRepository>();
            services.AddScoped<IEntityRepository<PurchaseReception, System.Guid>, PurchaseReceptionRepository>();
            services.AddScoped<IEntityRepository<Purchase, System.Guid>, PurchaseRepository>();
            services.AddScoped<IEntityRepository<PurchaseSpent, System.Guid>, PurchaseSpentRepository>();
            services.AddScoped<IEntityRepository<PurchaseZone, System.Guid>, PurchaseZoneRepository>();
            services.AddScoped<IEntityRepository<LegalProviderBudget, System.Guid>, LegalProviderBudgetRepository>();
            services.AddScoped<IEntityRepository<NaturalProviderBudget, System.Guid>, NaturalProviderBudgetRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.PurchasingDataInitializationHelper>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.PurchasingDbSchemaConfigurationProvider>();
        }
    }
}
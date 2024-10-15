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
            services.AddScoped<IEntityRepository<LegalProvider, System.Guid>, LegalProviderRepository>();
            services.AddScoped<IEntityRepository<NaturalProvider, System.Guid>, NaturalProviderRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.PurchasingDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorPurchasingContractualPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.PurchasingContractualDbSchemaConfigurationProvider>();
        }
    }
}
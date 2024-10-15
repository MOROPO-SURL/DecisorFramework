using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Sales.Persistence.Entities;
using MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Sales.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorSalesPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalClient, System.Guid>, LegalClientRepository>();
            services.AddScoped<IEntityRepository<NaturalClient, System.Guid>, NaturalClientRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.SalesDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorSalesContractualPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.SalesContractualDbSchemaConfigurationProvider>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Sales.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorSalesPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.SalesDbSchemaConfigurationProvider>();
        }
    }
}
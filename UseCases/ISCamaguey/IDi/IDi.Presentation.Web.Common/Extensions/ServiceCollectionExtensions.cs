using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorIDiPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.IDiDbSchemaConfigurationProvider>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorDomainPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DomainDbSchemaConfigurationProvider>();
        }
    }
}
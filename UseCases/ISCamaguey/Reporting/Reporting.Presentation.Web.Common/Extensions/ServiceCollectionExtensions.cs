using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Reporting.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorReportingPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ReportingDbSchemaConfigurationProvider>();
        }
    }
}
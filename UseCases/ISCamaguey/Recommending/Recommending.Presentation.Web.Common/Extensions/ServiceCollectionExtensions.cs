using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddISCamagueyDecisorRecommendingPresentationWebCommon(this IServiceCollection services)
    {
        services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.RecomendationReport, System.Guid>, Persistence.ORM.EF.Repositories.RecomendationReportRepository>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.RecommendingDbSchemaConfigurationProvider>();
    }
}
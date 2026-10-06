using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddISCamagueyDecisorProductionPresentationWebCommon(this IServiceCollection services)
    {
        services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ProductionQualityCheck, System.Guid>, Persistence.ORM.EF.Repositories.ProductionQualityCheckRepository>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ProductionDbSchemaConfigurationProvider>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ProductionDataInitializationHelper>();
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddISCamagueyDecisorDomainPresentationWebCommon(this IServiceCollection services)
    {
        services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Technique, System.Guid>, Persistence.ORM.EF.Repositories.TechniqueRepository>();
        services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.SampleKind, System.Guid>, Persistence.ORM.EF.Repositories.SampleKindRepository>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DomainDbSchemaConfigurationProvider>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.DomainDataInitializationHelper>();
    }
}
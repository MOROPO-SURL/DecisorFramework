using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorLabPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.WorkingGroup, System.Guid>, Persistence.ORM.EF.Repositories.WorkingGroupRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.SampleKind, System.Guid>, Persistence.ORM.EF.Repositories.SampleKindRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.LabDbSchemaConfigurationProvider>();
        }
    }
}
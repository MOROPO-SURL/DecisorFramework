using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorServicingPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.TrainingService, System.Guid>, Persistence.ORM.EF.Repositories.TrainingServiceRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.TrainingServiceStep, System.Guid>, Persistence.ORM.EF.Repositories.TrainingServiceStepRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.SampleAnalysisService, System.Guid>, Persistence.ORM.EF.Repositories.SampleAnalysisServiceRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.SampleAnalysisServiceStep, System.Guid>, Persistence.ORM.EF.Repositories.SampleAnalysisServiceStepRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ServicingDbSchemaConfigurationProvider>();
        }
    }
}
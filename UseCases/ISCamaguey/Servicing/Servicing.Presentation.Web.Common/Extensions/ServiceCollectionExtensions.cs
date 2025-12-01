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
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.GroundIntegralStudyService, System.Guid>, Persistence.ORM.EF.Repositories.GroundIntegralStudyServiceRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.GroundIntegralStudyServiceStep, System.Guid>, Persistence.ORM.EF.Repositories.GroundIntegralStudyServiceStepRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.LegalClientServicingContract, System.Guid>, Persistence.ORM.EF.Repositories.LegalClientServicingContractRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.NaturalClientServicingContract, System.Guid>, Persistence.ORM.EF.Repositories.NaturalClientServicingContractRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, long>, Persistence.ORM.EF.Repositories.LegalClientSampleAnalysisServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.NaturalClientSampleAnalysisServiceOrder, long>, Persistence.ORM.EF.Repositories.NaturalClientSampleAnalysisServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.LegalClientTrainingServiceOrder, long>, Persistence.ORM.EF.Repositories.LegalClientTrainingServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.NaturalClientTrainingServiceOrder, long>, Persistence.ORM.EF.Repositories.NaturalClientTrainingServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder, long>, Persistence.ORM.EF.Repositories.LegalClientGroundIntegralStudyServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder, long>, Persistence.ORM.EF.Repositories.NaturalClientGroundIntegralStudyServiceOrderRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ServicingDbSchemaConfigurationProvider>();
        }
    }
}
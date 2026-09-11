using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorLabPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.WorkingGroup, System.Guid>, Persistence.ORM.EF.Repositories.WorkingGroupRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long>, Persistence.ORM.EF.Repositories.SampleAnalysisServiceOrderRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Contract.AbstractSample, System.Guid>, Persistence.ORM.EF.Repositories.SampleRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ServiceOrderSample, System.Guid>, Persistence.ORM.EF.Repositories.ServiceOrderSampleRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ResearchSample, System.Guid>, Persistence.ORM.EF.Repositories.ResearchSampleRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ProductionSample, System.Guid>, Persistence.ORM.EF.Repositories.ProductionSampleRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.WorkPlan, System.Guid>, Persistence.ORM.EF.Repositories.WorkPlanRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Analysis, System.Guid>, Persistence.ORM.EF.Repositories.AnalysisRepository>();
            services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Assessment, System.Guid>, Persistence.ORM.EF.Repositories.AssessmentRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.LabDbSchemaConfigurationProvider>();
        }
    }
}
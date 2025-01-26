using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorProductionPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Elaboration, System.Guid>, ElaborationRepository>();
            services.AddScoped<IEntityRepository<ElaborationStep, System.Guid>, ElaborationStepRepository>();
            services.AddScoped<IEntityRepository<ProductionPlan, System.Guid>, ProductionPlanRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Production, System.Guid>, ProductionRepository>();
            services.AddScoped<IEntityRepository<ProductionRole, System.Guid>, ProductionRoleRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ProductionDbSchemaConfigurationProvider>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ProductionDataInitializationHelper>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorIDiPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<ResearchArea, System.Guid>, ResearchAreaRepository>();
            services.AddScoped<IEntityRepository<Program, System.Guid>, ProgramRepository>();
            services.AddScoped<IEntityRepository<ProgramExpectResult, System.Guid>, ProgramExpectResultRepository>();
            services.AddScoped<IEntityRepository<ResearcherCategory, System.Guid>, ResearcherCategoryRepository>();
            services.AddScoped<IEntityRepository<TeachingCategory, System.Guid>, TeachingCategoryRepository>();
            services.AddScoped<IEntityRepository<ParticipatingOrganization, System.Guid>, ParticipatingOrganizationRepository>();
            services.AddScoped<IEntityRepository<Financier, System.Guid>, FinancierRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.IDiDbSchemaConfigurationProvider>();
        }
    }
}
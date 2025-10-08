using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorHumanResourcesPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Schooling, System.Guid>, SchoolingRepository>();
            services.AddScoped<IEntityRepository<WorkPositionKind, System.Guid>, WorkPositionKindRepository>();
            services.AddScoped<IEntityRepository<WorkPosition, System.Guid>, WorkPositionRepository>();
            services.AddScoped<IEntityRepository<NamingResolution, System.Guid>, NamingResolutionRepository>();
            services.AddScoped<IEntityRepository<SalaryStandard, System.Guid>, SalaryStandardRepository>();
            services.AddScoped<IEntityRepository<Workforce, System.Guid>, WorkforceRepository>();
            services.AddScoped<IEntityRepository<WorkforceOrganizationalUnity, System.Guid>, WorkforceOrganizationalUnityRepository>();
            services.AddScoped<IEntityRepository<Staff, System.Guid>, StaffRepository>();
            services.AddScoped<IEntityRepository<Vacant, System.Guid>, VacantRepository>();
            services.AddScoped<IEntityRepository<Ocupation, System.Guid>, OcupationRepository>();
            services.AddScoped<IEntityRepository<VacantPostulation, System.Guid>, VacantPostulationRepository>();
            services.AddScoped<IEntityRepository<VacantPostulationOcupation, System.Guid>, VacantPostulationOcupationRepository>();
            services.AddScoped<IEntityRepository<OcupationCandidate, System.Guid>, OcupationCandidateRepository>();
            services.AddScoped<IEntityRepository<AdmitionPropousal, System.Guid>, AdmitionPropousalRepository>();
            services.AddScoped<IEntityRepository<AdmitionEmploymentContract, int>, AdmitionEmploymentContractRepository>();
            services.AddScoped<IEntityRepository<NamingEmploymentContract, int>, NamingEmploymentContractRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.HumanResourcesDbSchemaConfigurationProvider>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.HumanResourcesDataInitializationHelper>();
        }
    }
}

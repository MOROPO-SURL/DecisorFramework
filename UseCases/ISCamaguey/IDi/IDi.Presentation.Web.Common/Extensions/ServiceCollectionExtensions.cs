using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddISCamagueyDecisorIDiPresentationWebCommon(this IServiceCollection services)
    {
        services.AddScoped<IEntityRepository<ResearchArea, System.Guid>, ResearchAreaRepository>();
        services.AddScoped<IEntityRepository<Program, System.Guid>, ProgramRepository>();
        services.AddScoped<IEntityRepository<ProgramKind, System.Guid>, ProgramKindRepository>();
        services.AddScoped<IEntityRepository<ProgramExpectResult, System.Guid>, ProgramExpectResultRepository>();
        services.AddScoped<IEntityRepository<ResearcherCategory, System.Guid>, ResearcherCategoryRepository>();
        services.AddScoped<IEntityRepository<TeachingCategory, System.Guid>, TeachingCategoryRepository>();
        services.AddScoped<IEntityRepository<ParticipatingOrganization, System.Guid>, ParticipatingOrganizationRepository>();
        services.AddScoped<IEntityRepository<Financier, System.Guid>, FinancierRepository>();
        services.AddScoped<IEntityRepository<InternalResearcher, System.Guid>, InternalResearcherRepository>();
        services.AddScoped<IEntityRepository<ExternalResearcher, System.Guid>, ExternalResearcherRepository>();
        services.AddScoped<IEntityRepository<CallForProposal, System.Guid>, CallForProposalRepository>();
        services.AddScoped<IEntityRepository<ProjectProposal, System.Guid>, ProjectProposalRepository>();
        services.AddScoped<IEntityRepository<ProjectCategory, System.Guid>, ProjectCategoryRepository>();
        services.AddScoped<IEntityRepository<Project, System.Guid>, ProjectRepository>();
        services.AddScoped<IEntityRepository<ProjectSpecificObjective, System.Guid>, ProjectSpecificObjectiveRepository>();

        services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.IDiDbSchemaConfigurationProvider>();
    }
}
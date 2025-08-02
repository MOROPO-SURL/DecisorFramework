using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorGovernancePresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<DecisionMakingGroup, System.Guid>, DecisionMakingGroupRepository>();
            services.AddScoped<IEntityRepository<Meeting, System.Guid>, MeetingRepository>();
            services.AddScoped<IEntityRepository<Agreement, System.Guid>, AgreementRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.GovernanceDbSchemaConfigurationProvider>();
        }
    }
}

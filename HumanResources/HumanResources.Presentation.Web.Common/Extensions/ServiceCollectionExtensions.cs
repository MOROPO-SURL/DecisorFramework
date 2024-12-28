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
            services.AddScoped<IEntityRepository<Employee, System.Guid>, EmployeeRepository>();
            services.AddScoped<IEntityRepository<NamingResolution, long>, NamingResolutionRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.HumanResourcesDbSchemaConfigurationProvider>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.HumanResourcesDataInitializationHelper>();
        }
    }
}

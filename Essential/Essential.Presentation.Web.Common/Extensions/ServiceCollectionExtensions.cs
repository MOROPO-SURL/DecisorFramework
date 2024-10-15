using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Essential.Persistence.Entities;
using MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorEssentialPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Employee, System.Guid>, EmployeeRepository>();
            services.AddScoped<IEntityRepository<Colaborator, System.Guid>, ColaboratorRepository>();
            services.AddScoped<IEntityRepository<UnitMeasurement, System.Guid>, UnitMeasurementRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.EssentialDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorEssentialContractualPresentationWebCommon(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.EssentialContractualDbSchemaConfigurationProvider>();
        }
    }
}


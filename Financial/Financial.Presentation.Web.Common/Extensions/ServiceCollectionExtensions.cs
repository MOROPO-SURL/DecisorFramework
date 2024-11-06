using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorFinancialPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.CostCenter, System.Guid>, Persistence.ORM.EF.Repositories.CostCenterRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.FinantialDbSchemaConfigurationProvider>();
        }
    }
}


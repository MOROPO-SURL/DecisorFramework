using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Servicing.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorServicingPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Service, System.Guid>, Persistence.ORM.EF.Repositories.ServiceRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.ServicingDbSchemaConfigurationProvider>();
        }
    }
}


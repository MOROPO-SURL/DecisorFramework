using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Persistence.Entities;
using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorCorePresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalBusinessKind, System.Guid>, LegalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<NaturalBusinessKind, System.Guid>, NaturalBusinessKindRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.CoreDbSchemaConfigurationProvider>();
        }
    }
}


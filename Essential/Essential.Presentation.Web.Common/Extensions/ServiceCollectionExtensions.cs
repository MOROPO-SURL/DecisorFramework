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
            services.AddScoped<IEntityRepository<Colaborator, System.Guid>, ColaboratorRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.EssentialDbSchemaConfigurationProvider>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.EssentialDataInitializationHelper>();
        }
    }
}


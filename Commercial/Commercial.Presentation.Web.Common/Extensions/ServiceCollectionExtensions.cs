using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorCommercialPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalBusinessKind, System.Guid>, LegalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<NaturalBusinessKind, System.Guid>, NaturalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<LegalProvider, System.Guid>, LegalProviderRepository>();
            services.AddScoped<IEntityRepository<NaturalProvider, System.Guid>, NaturalProviderRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.CommercialDbSchemaConfigurationProvider>();
        }
    }
}
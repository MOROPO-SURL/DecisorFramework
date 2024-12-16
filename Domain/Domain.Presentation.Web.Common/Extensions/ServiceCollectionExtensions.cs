using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorDomainPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Persistence.Entities.PropertyKind, System.Guid>, Persistence.ORM.EF.Repositories.PropertyKindRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.VehicleEngineKind, System.Guid>, Persistence.ORM.EF.Repositories.VehicleEngineKindRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.StructureKind, System.Guid>, Persistence.ORM.EF.Repositories.StructureKindRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DomainDbSchemaConfigurationProvider>();
        }
    }
}


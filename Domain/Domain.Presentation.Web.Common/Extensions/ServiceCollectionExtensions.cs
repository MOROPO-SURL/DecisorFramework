using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorDomainPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<PropertyKind, System.Guid>, PropertyKindRepository>();
            services.AddScoped<IEntityRepository<VehicleEngineKind, System.Guid>, VehicleEngineKindRepository>();
            services.AddScoped<IEntityRepository<StructureKind, System.Guid>, StructureKindRepository>();
            services.AddScoped<IEntityRepository<OrganizationalUnity, System.Guid>, OrganizationalUnityRepository>();
            services.AddScoped<IEntityRepository<Structure, System.Guid>, StructureRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DomainDbSchemaConfigurationProvider>();
        }
    }
}


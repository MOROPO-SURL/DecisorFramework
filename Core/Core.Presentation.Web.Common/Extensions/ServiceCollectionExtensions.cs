using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Persistence.Entities;
using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorPresentationWebCommonEssential(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Employee, System.Guid>, EmployeeRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.EssentialDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorPresentationWebCommonBusinessRelationship(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalBusinessKind, System.Guid>, LegalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<NaturalBusinessKind, System.Guid>, NaturalBusinessKindRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.BusinessRelationshipDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorPresentationWebCommonSales(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalClient, System.Guid>, LegalClientRepository>();
            services.AddScoped<IEntityRepository<NaturalClient, System.Guid>, NaturalClientRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.SalesDbSchemaConfigurationProvider>();
        }

        public static void AddDecisorPresentationWebCommonPurchasing(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<LegalProvider, System.Guid>, LegalProviderRepository>();
            services.AddScoped<IEntityRepository<NaturalProvider, System.Guid>, NaturalProviderRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.PurchasingDbSchemaConfigurationProvider>();
        }
    }
}


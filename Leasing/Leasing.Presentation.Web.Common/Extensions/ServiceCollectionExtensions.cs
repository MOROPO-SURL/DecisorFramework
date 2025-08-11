using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorLeasingPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<PropertyLeasePropousal, System.Guid>, PropertyLeasePropousalRepository>();
            services.AddScoped<IEntityRepository<PropertySpaceLeasePropousal, System.Guid>, PropertySpaceLeasePropousalRepository>();
            services.AddScoped<IEntityRepository<VehicleLeasePropousal, System.Guid>, VehicleLeasePropousalRepository>();
            services.AddScoped<IEntityRepository<PropertyLeaseOffer, System.Guid>, PropertyLeaseOfferRepository>();
            services.AddScoped<IEntityRepository<VehicleLeaseOffer, System.Guid>, VehicleLeaseOfferRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.LeasingDbSchemaConfigurationProvider>();
        }
    }
}

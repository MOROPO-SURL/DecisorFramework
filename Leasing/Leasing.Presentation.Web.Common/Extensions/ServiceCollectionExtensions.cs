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
            services.AddScoped<IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid>, VehicleLeaseOrganizationPostulationRepository>();
            services.AddScoped<IEntityRepository<VehicleLeasePersonPostulation, System.Guid>, VehicleLeasePersonPostulationRepository>();
            services.AddScoped<IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid>, PropertyLeaseOrganizationPostulationRepository>();
            services.AddScoped<IEntityRepository<PropertyLeasePersonPostulation, System.Guid>, PropertyLeasePersonPostulationRepository>();
            services.AddScoped<IEntityRepository<SupervisionGroup, System.Guid>, SupervisionGroupRepository>();
            services.AddScoped<IEntityRepository<LegalClientVehicleLeaseContract, System.Guid>, LegalClientVehicleLeaseContractRepository>();
            services.AddScoped<IEntityRepository<LegalClientVehicleLeasing, System.Guid>, LegalClientVehicleLeasingRepository>();
            services.AddScoped<IEntityRepository<NaturalClientVehicleLeaseContract, System.Guid>, NaturalClientVehicleLeaseContractRepository>();
            services.AddScoped<IEntityRepository<NaturalClientVehicleLeasing, System.Guid>, NaturalClientVehicleLeasingRepository>();
            services.AddScoped<IEntityRepository<LegalClientPropertyLeaseContract, System.Guid>, LegalClientPropertyLeaseContractRepository>();
            services.AddScoped<IEntityRepository<LegalClientPropertyLeasing, System.Guid>, LegalClientPropertyLeasingRepository>();
            services.AddScoped<IEntityRepository<NaturalClientPropertyLeaseContract, System.Guid>, NaturalClientPropertyLeaseContractRepository>();
            services.AddScoped<IEntityRepository<NaturalClientPropertyLeasing, System.Guid>, NaturalClientPropertyLeasingRepository>();
            services.AddScoped<IEntityRepository<LegalClientPropertyLeasingCollect, System.Guid>, LegalClientPropertyLeasingCollectRepository>();
            services.AddScoped<IEntityRepository<LegalClientVehicleLeasingCollect, System.Guid>, LegalClientVehicleLeasingCollectRepository>();
            services.AddScoped<IEntityRepository<NaturalClientPropertyLeasingCollect, System.Guid>, NaturalClientPropertyLeasingCollectRepository>();
            services.AddScoped<IEntityRepository<NaturalClientVehicleLeasingCollect, System.Guid>, NaturalClientVehicleLeasingCollectRepository>();
            services.AddScoped<IEntityRepository<DriveLicence, System.Guid>, DriveLicenceRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.LeasingDbSchemaConfigurationProvider>();
        }
    }
}

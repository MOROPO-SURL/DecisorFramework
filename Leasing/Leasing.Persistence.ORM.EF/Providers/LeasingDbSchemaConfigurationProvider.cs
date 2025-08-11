using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Providers
{
    public class LeasingDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.VehicleLeasePropousal>(),
                    new BaseEntityTypeConfigurator<Entities.PropertyLeasePropousal>(),
                    new Configurators.PropertySpaceLeasePropousalEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.VehicleLeaseOffer>(),
                    new Configurators.VehicleLeaseOfferClauseBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.VehicleLeaseOrganizationPostulation>(),
                    new Configurators.VehicleLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.VehicleLeasePersonPostulation>(),
                    new Configurators.VehicleLeasePersonPostulationDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PropertyLeaseOffer>(),
                    new Configurators.PropertyLeaseOfferClauseBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PropertyLeaseOrganizationPostulation>(),
                    new Configurators.PropertyLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PropertyLeasePersonPostulation>(),
                    new Configurators.PropertyLeasePersonPostulationDocumentBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_leasing";
    }
}

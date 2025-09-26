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
                    new Configurators.PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridgeEntitTypeConfigurator(),
                    new Configurators.PropertyLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.PropertyLeasePersonPostulation>(),
                    new Configurators.PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridgeEntityTypeConfigurator(),
                    new Configurators.PropertyLeasePersonPostulationDocumentBridgeEntityTypeConfigurator(),
                    new Configurators.LeaseContractEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientPropertyLeaseContract>(),
                    new Configurators.LegalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientVehicleLeaseContract>(),
                    new Configurators.NaturalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientVehicleLeaseContract>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientVehicleLeaseContract>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientVehicleLeasing>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientVehicleLeasing>(),
                    new Configurators.LegalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientPropertyLeasing>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientPropertyLeasing>(),
                    new Configurators.LegalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.SupervisionGroup>(),
                    new Configurators.SupervisionGroupsEmployeeBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientPropertySupervisionControlAction>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientPropertySupervisionControlAction>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientVehicleSupervisionControlAction>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientVehicleSupervisionControlAction>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientPropertyLeasingCompensation>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientPropertyLeasingCompensation>(),
                    new Configurators.LegalClientPropertyLeasingCompensationDocumentBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientPropertyLeasingCompensationDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientVehicleLeasingCompensation>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientVehicleLeasingCompensation>(),
                    new Configurators.LegalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_leasing";
    }
}

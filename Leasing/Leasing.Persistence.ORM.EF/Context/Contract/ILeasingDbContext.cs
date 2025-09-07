using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Context.Contract
{
    public interface ILeasingDbContext : Governance.Persistence.ORM.EF.Context.Contract.IGovernanceDbContext
    {
        public DbSet<Entities.PropertyLeasePropousal> PropertyLeasePropousals { get; set; }
        public DbSet<Entities.PropertySpaceLeasePropousal> PropertySpaceLeasePropousals { get; set; }
        public DbSet<Entities.VehicleLeasePropousal> VehicleLeasePropousals { get; set; }
        public DbSet<Entities.PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<Entities.VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulation> VehLeasOrgPostulations { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulationDocumentBridge> VehLeasOrgPostDocumentBridges { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulation> VehLeasPersonPostulations { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulationDocumentBridge> VehLeasPersonPostDocumentBridges { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulation> PropLeasOrgPostulations { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropLeaseOrgPostSpacePropousalBridges { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulationDocumentBridge> PropLeasOrgPostDocumentBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulation> PropLeasPersonPostulations { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge> PropLeasPersPostSpacePropBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulationDocumentBridge> PropertyLeasePersonPostulationDocumentBridges { get; set; }
        public DbSet<Entities.LegalClientPropertyLeaseContract> LegalClientPropertyLeaseContract { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeaseContract> NaturalClientPropertyLeaseContract { get; set; }
        public DbSet<Entities.LegalClientPropertyLeaseContractSpaceBridge> LegClientPropLeasContractSpaceBridges { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeaseContractSpaceBridge> NatClientPropeLeasContractSpaceBridges { get; set; }
        public DbSet<Entities.LegalClientVehicleLeaseContract> LegalClientVehicleLeaseContract { get; set; }
        public DbSet<Entities.NaturalClientVehicleLeaseContract> NaturalClientVehicleLeaseContract { get; set; }
        public DbSet<Entities.LegalClientVehicleLeasing> LegalClientVehicleLeasings { get; set; }
        public DbSet<Entities.LegalClientVehicleLeasingPersonContactBridge> LegClientVehLeasPersonContactBridges { get; set; }
        public DbSet<Entities.NaturalClientVehicleLeasing> NaturalClientVehicleLeasings { get; set; }
        public DbSet<Entities.NaturalClientVehicleLeasingPersonContactBridge> NatClientVehLeasPersonContactBridges { get; set; }
        public DbSet<Entities.LegalClientPropertyLeasing> LegalClientPropertyLeasings { get; set; }
        public DbSet<Entities.LegalClientPropertyLeasingPersonContactBridge> LegClientPropLeasPersonContactBridges { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeasing> NaturalClientPropertyLeasings { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeasingPersonContactBridge> NatClientPropLeasPersonContactBridges { get; set; }
        public DbSet<Entities.SupervisionGroup> SupervisionGroups { get; set; }
        public DbSet<Entities.SupervisionGroupEmployeeBridge> SupervisionGroupEmployeeBridges { get; set; }
        public DbSet<Entities.LegalClientPropertySupervisionControlAction> LegClientPropSupervControlActions { get; set; }
        public DbSet<Entities.NaturalClientPropertySupervisionControlAction> NatClientPropSupervControlActions { get; set; }
        public DbSet<Entities.LegalClientVehicleSupervisionControlAction> LegClientVehSupervControlActions { get; set; }
        public DbSet<Entities.NaturalClientVehicleSupervisionControlAction> NatClientVehSupervControlActions { get; set; }
        public DbSet<Entities.LegalClientPropertyLeasingCompensation> LegalClientPropertyLeasingCompensations { get; set; }
        public DbSet<Entities.LegalClientPropertyLeasingCompensationDocumentBridge> LegClientPropLeasCompDocumentBridges { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeasingCompensation> NaturalClientPropertyLeasingCompensations { get; set; }
        public DbSet<Entities.NaturalClientPropertyLeasingCompensationDocumentBridge> NatClientPropLeasCompDocumentBridges { get; set; }
        public DbSet<Entities.LegalClientVehicleLeasingCompensation> LegalClientVehicleLeasingCompensations { get; set; }
        public DbSet<Entities.LegalClientVehicleLeasingCompensationDocumentBridge> LegClientVehLeasCompDocumentBridges { get; set; }
        public DbSet<Entities.NaturalClientVehicleLeasingCompensation> NaturalClientVehicleLeasingCompensations { get; set; }
        public DbSet<Entities.NaturalClientVehicleLeasingCompensationDocumentBridge> NatClientVehLeasCompDocumentBridges { get; set; }
    }
}
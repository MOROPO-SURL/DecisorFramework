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
        public DbSet<Entities.VehicleLeaseOrganizationPostulation> VehicleLeaseOrganizationPostulations { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulationDocumentBridge> VehicleLeaseOrganizationPostulationDocumentBridges { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulation> VehicleLeasePersonPostulations { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulationDocumentBridge> VehicleLeasePersonPostulationDocumentBridges { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulation> PropertyLeaseOrganizationPostulations { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge> PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridges { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulationDocumentBridge> PropertyLeaseOrganizationPostulationDocumentBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulation> PropertyLeasePersonPostulations { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge> PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulationDocumentBridge> PropertyLeasePersonPostulationDocumentBridges { get; set; }
    }
}
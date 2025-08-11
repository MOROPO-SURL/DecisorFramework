using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Context.Contract
{
    public interface ILeasingDbContext : Governance.Persistence.ORM.EF.Context.Contract.IGovernanceDbContext
    {
        public DbSet<Entities.PropertyLeasePropousal> PropertyLeasePropousals { get; set; }
        public DbSet<Entities.PropertySpaceLeasePropousal> PropertySpaceLeasePropousals { get; set; }
        public DbSet<Entities.VehicleLeasePropousal> VehicleLeasePropousals { get; set; }
        public DbSet<Entities.PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulation> PropertyLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulation> PropertyLeaseOfferPersonContactBridges { get; set; }
        public DbSet<Entities.VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulation> VehicleLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulation> VehicleLeaseOfferPersonContactBridges { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Context.Contract
{
    public interface ILeasingDbContext : HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
    {
        public DbSet<Entities.PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulation> PropertyLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulation> PropertyLeaseOfferPersonContactBridges { get; set; }
        public DbSet<Entities.VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulation> VehicleLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulation> VehicleLeaseOfferPersonContactBridges { get; set; }
    }
}
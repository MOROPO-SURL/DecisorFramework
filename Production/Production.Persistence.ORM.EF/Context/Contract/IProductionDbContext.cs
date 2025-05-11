using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Context.Contract
{
    public interface IProductionDbContext : Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext, Essential.Persistence.ORM.EF.Context.Contract.IEssentialDbContext
    {
        public DbSet<Entities.Elaboration> Elaborations { get; set; }
        public DbSet<Entities.ElaborationInputProductBridge> ElaborationInputProductBridges { get; set; }
        public DbSet<Entities.ElaborationInputProductClassificationBridge> ElaborationInputProductClassificationBridges { get; set; }
        public DbSet<Entities.ElaborationOutputProductBridge> ElaborationOutputProductBridges { get; set; }
        public DbSet<Entities.ElaborationStep> ElaborationSteps { get; set; }
        public DbSet<Entities.ElaborationStepWorkPositionBridge> ElaborationStepWorkPositionBridges { get; set; }
        public DbSet<Entities.Production> Productions { get; set; }
        public DbSet<Entities.ProductionColaboratorBridge> ProductionColaboratorBridges { get; set; }
        public DbSet<Entities.ProductionEmployeeBridge> ProductionEmployeeBridges { get; set; }
        public DbSet<Entities.ProductionOrder> ProductionOrders { get; set; }
        public DbSet<Entities.ProductionOrderDeparture> ProductionOrderDepartures { get; set; }
        public DbSet<Entities.ProductionProductBridge> ProductionProductBridges { get; set; }
        public DbSet<Entities.ProductionReception> ProductionReceptions { get; set; }
        public DbSet<Entities.PropertyLeaseOffer> PropertyLeaseOffers { get; set; }
        public DbSet<Entities.PropertyLeaseOrganizationPostulation> PropertyLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.PropertyLeasePersonPostulation> PropertyLeaseOfferPersonContactBridges { get; set; }
        public DbSet<Entities.VehicleLeaseOffer> VehicleLeaseOffers { get; set; }
        public DbSet<Entities.VehicleLeaseOrganizationPostulation> VehicleLeaseOfferOrganizationContactBridges { get; set; }
        public DbSet<Entities.VehicleLeasePersonPostulation> VehicleLeaseOfferPersonContactBridges { get; set; }
    }
}

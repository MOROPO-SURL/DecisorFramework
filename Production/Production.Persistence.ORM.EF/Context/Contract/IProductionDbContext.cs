using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Context.Contract
{
    public interface IProductionDbContext : Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext
    {
        public DbSet<Persistence.Entities.Elaboration> Elaborations { get; set; }
        public DbSet<Persistence.Entities.ElaborationInputProductBridge> ElaborationInputProductBridges { get; set; }
        public DbSet<Persistence.Entities.ElaborationOutputProductBridge> ElaborationOutputProductBridges { get; set; }
        public DbSet<Persistence.Entities.ElaborationStep> ElaborationSteps { get; set;}
        public DbSet<Persistence.Entities.ElaborationStepProductionRoleBridge> ElaborationStepProductionRoleBridges { get; set; }
        public DbSet<Persistence.Entities.Production> Productions { get; set; }
        public DbSet<Persistence.Entities.ProductionColaboratorBridge> ProductionColaboratorBridges { get; set; }
        public DbSet<Persistence.Entities.ProductionEmployeeBridge> ProductionEmployeeBridges { get; set; }
        public DbSet<Persistence.Entities.ProductionPlan> ProductionPlans { get; set; }
        public DbSet<Persistence.Entities.ProductionPlanDeparture> ProductionPlanDepartures { get; set; }
        public DbSet<Persistence.Entities.ProductionProductBridge> ProductionProductBridges { get; set; }
        public DbSet<Persistence.Entities.ProductionReception> ProductionReceptions { get; set; }
        public DbSet<Persistence.Entities.ProductionRole> ProductionRoles { get; set; }
    }
}

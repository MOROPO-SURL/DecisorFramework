using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Context.Contract
{
    public interface IInventoryDbContext : Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
    {
		public DbSet<Entities.CustomAttribute> CustomAttributes { get; set; }
		public DbSet<Entities.Product> Products { get; set; }
		public DbSet<Entities.Classification> Classifications { get; set; }
		public DbSet<Entities.Family> Families { get; set; }
		public DbSet<Entities.ProductCustomAttributeBridge> ProductCustomAttributeBridges { get; set; }
		public DbSet<Entities.ProductWarehousingDecreaseKindBridge> ProductWarehousingDecreaseKindBridges { get; set; }
		public DbSet<Entities.Warehouse> Warehouses { get; set; }
		public DbSet<Entities.WarehousingArea> WarehousingAreas { get; set; }
		public DbSet<Entities.Batch> Batches { get; set; }
		public DbSet<Entities.TransferReception> TransferReceptions { get; set; }
		public DbSet<Entities.Contract.AbstractDeparture> Departures { get; set; }
		public DbSet<Entities.DepartureBatchBridge> DepartureBatchBridges { get; set; }
        public DbSet<Entities.ReceptionBatchBridge> ReceptionBatchBridges { get; set; }
    }
}


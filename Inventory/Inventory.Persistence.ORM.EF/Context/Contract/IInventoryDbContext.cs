using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Context.Contract
{
	public interface IInventoryDbContext : Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
    {
		public DbSet<Entities.CustomAttribute> CustomAttributes { get; set; }
		public DbSet<Entities.Product> Products { get; set; }
		public DbSet<Entities.ProductCustomAttributeBridge> ProductCustomAttributeBridges { get; set; }
		public DbSet<Entities.ProductWarehousingDecreaseKindBridge> ProductWarehousingDecreaseKindBridges { get; set; }
		public DbSet<Entities.Warehouse> Warehouses { get; set; }
		public DbSet<Entities.Batch> Batches { get; set; }
		public DbSet<Entities.Contract.AbstractReception> Receptions { get; set; }
		public DbSet<Entities.Contract.AbstractDeparture> Departures { get; set; }
		public DbSet<Entities.DepartureBatchBridge> DepartureBatchBridges { get; set; }
	}
}


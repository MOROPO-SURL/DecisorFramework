using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Context.Contract
{
	public interface ISaleContractualDbContext : ISalesDbContext, Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext
    {
        public DbSet<Entities.LegalClientSaleContract> LegalClientSaleContracts { get; set; }
        public DbSet<Entities.NaturalClientSaleContract> NaturalClientSaleContracts { get; set; }
        public DbSet<Entities.LegalClientWholesaleSale> LegalClientWholesaleSales { get; set; }
        public DbSet<Entities.NaturalClientWholesaleSale> NaturalClientWholesaleSales { get; set; }
    }
}


namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Context.Contract
{
	public interface IPurchasingContractualDbContext : IPurchasingDbContext, Inventory.Persistence.ORM.EF.Context.Contract.IInventoryDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.LegalProviderPurchasingContract> LegalProviderPurchasingContracts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NaturalProviderPurchasingContract> NaturalProviderPurchasingContracts { get; set; }
    }
}
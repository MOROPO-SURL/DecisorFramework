namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Context.Contract
{
	public interface IPurchasingContractualDbContext : IPurchasingDbContext, Essential.Persistence.ORM.EF.Context.Contract.IEssentialContractualDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.LegalProviderPurchasingContract> LegalProviderPurchasingContracts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NaturalProviderPurchasingContract> NaturalProviderPurchasingContracts { get; set; }
    }
}
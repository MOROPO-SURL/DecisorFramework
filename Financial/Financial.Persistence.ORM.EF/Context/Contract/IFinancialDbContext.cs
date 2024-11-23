using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Context.Contract
{
	public interface IFinancialDbContext : Essential.Persistence.ORM.EF.Context.Contract.IEssentialDbContext
    {
		public DbSet<Entities.BankAgency> BankAgencies { get; set; }
		public DbSet<Entities.BankBranch> BankBranches { get; set; }
		public DbSet<Entities.BankAccount> BankAccounts { get; set; }
		public DbSet<Entities.CostCenter> CostCenters { get; set; }
		public DbSet<Entities.Contract.AbstractCashAdvance> Advances { get; set; }
	}
}


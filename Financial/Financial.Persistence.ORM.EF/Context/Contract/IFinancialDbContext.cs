using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Context.Contract
{
	public interface IFinancialDbContext : Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext
    {
		public DbSet<Entities.Currency> Currencies { get; set; }
		public DbSet<Entities.BankAgency> BankAgencies { get; set; }
		public DbSet<Entities.BankBranch> BankBranches { get; set; }
		public DbSet<Entities.BankAccount> BankAccounts { get; set; }
		public DbSet<Entities.BankDebitCard> BankDebitCards { get; set; }
		public DbSet<Entities.CostCenter> CostCenters { get; set; }
		// TODO Review if required !!
		//public DbSet<Entities.Contract.AbstractCashAdvance> Advances { get; set; }
	}
}


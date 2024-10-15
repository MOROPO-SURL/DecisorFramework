namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Context.Contract
{
	public interface IEssentialContractualDbContext : IEssentialDbContext
	{
        public Microsoft.EntityFrameworkCore.DbSet<Entities.BankAgency> BankAgencies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.BankBranch> BankBranches { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.BankAccount> BankAccounts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.EmploymentContract> EmploymentContracts { get; set; }
	}
}

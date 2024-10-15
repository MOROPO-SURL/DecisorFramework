namespace MOROPO.Framework.Decisor.Servicing.Persistence.ORM.EF.Context.Contract
{
	public interface IServicingDbContext : Financial.Persistence.ORM.EF.Context.Contract.IFinancialDbContext
    {
		public Microsoft.EntityFrameworkCore.DbSet<Entities.Service> Services { get; set; }
	}
}


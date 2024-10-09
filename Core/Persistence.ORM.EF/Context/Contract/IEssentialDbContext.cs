namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Context.Contract
{
	public interface IEssentialDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Employee> Employees { get; set; }
    }
}


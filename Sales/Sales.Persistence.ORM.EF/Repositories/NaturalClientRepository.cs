namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Repositories
{
	public class NaturalClientRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClient, System.Guid>
	{
		public NaturalClientRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


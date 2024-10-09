namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories
{
	public class NaturalProviderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalProvider, System.Guid>
	{
		public NaturalProviderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


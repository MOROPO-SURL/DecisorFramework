namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories
{
	public class LegalProviderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.LegalProvider, System.Guid>
	{
		public LegalProviderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}

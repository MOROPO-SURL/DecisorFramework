namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
	public class LegalProviderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalProvider, System.Guid>
	{
		public LegalProviderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}

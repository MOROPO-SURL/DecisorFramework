namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Repositories
{
	public class LegalClientRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClient, System.Guid>
	{
		public LegalClientRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
	public class RequestableServiceRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.RequestableService, System.Guid>
	{
		public RequestableServiceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


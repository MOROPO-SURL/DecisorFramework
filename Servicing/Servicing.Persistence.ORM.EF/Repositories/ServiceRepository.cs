namespace MOROPO.Framework.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
	public class ServiceRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Service, System.Guid>
	{
		public ServiceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


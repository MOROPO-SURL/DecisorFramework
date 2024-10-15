namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
	public class CostCenterRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CostCenter, System.Guid>
	{
		public CostCenterRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}
	}
}


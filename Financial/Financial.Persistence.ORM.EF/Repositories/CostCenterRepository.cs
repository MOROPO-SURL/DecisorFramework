using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
	public class CostCenterRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CostCenter, System.Guid>
	{
		public CostCenterRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
        }

        protected override System.Linq.IQueryable<Entities.CostCenter> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.DefaultBankAccount).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.DefaultBankAccount).ThenInclude(entity => entity.Currency);
        }
    }
}


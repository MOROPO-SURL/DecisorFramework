using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class WorkPositionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WorkPosition, System.Guid>
    {
        public WorkPositionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.WorkPosition> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .AsNoTracking()
                .Include(entity => entity.Kind);
        }
    }
}

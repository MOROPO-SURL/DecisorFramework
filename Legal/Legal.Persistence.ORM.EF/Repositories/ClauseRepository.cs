using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class ClauseRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Clause, System.Guid>
    {
        public ClauseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Clause> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.TagBridges);
        }
    }
}

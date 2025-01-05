using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class VacantRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Vacant, System.Guid>
    {
        public VacantRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Vacant> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Kind)
                .Include(entity => entity.Schooling);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class BatchRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Batch, System.Guid>
    {
        public BatchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Batch> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Warehouse);
        }
    }
}

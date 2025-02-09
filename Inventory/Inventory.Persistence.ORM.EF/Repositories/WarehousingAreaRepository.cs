using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class WarehousingAreaRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WarehousingArea, System.Guid>
    {
        public WarehousingAreaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.WarehousingArea> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.UnitMeasurement);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class ProductRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Product, System.Guid>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Product> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.UnitMeasurement)
                .Include(entity => entity.FeatureImage)
                .Include(entity => entity.Classifications)
                .Include(entity => entity.WarehousingDecreaseKindBridges);
        }

        public override System.Func<Entities.Product, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}

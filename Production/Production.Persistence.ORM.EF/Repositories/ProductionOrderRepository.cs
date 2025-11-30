using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ProductionOrderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProductionOrder, System.Guid>
    {
        public ProductionOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ProductionOrder> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Elaboration).ThenInclude(entity => entity.Product).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.Elaboration).ThenInclude(entity => entity.Product).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}


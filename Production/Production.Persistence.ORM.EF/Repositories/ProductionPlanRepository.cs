using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ProductionPlanRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProductionPlan, System.Guid>
    {
        public ProductionPlanRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ProductionPlan> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Elaboration).ThenInclude(entity => entity.Product).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.Elaboration.OutputProductBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Planner).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Decisor).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}


using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchasePlanRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.PurchasePlan, System.Guid>
    {
        public PurchasePlanRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Persistence.Entities.PurchasePlan> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Zone).ThenInclude(entity => entity.SpentBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Planner).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Decisor).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.LegalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.LegalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.NaturalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.NaturalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.InputProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.InputProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.OutputProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.OutputProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.Purchase);
        }
    }
}

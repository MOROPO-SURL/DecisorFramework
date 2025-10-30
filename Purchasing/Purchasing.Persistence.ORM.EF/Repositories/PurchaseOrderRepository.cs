using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseOrderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseOrder, System.Guid>
    {
        public PurchaseOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.PurchaseOrder> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Zone).ThenInclude(entity => entity.SpentBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Zone).ThenInclude(entity => entity.SpentBridges).ThenInclude(bridge => bridge.Currency)
                .Include(entity => entity.Request).ThenInclude(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Request).ThenInclude(entity => entity.ProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.LegalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.LegalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.NaturalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.NaturalProviderBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.ResultProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ResultProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.SpentProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.SpentProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.AdvanceRequiredCurrency)
                .Include(entity => entity.Purchase);
        }
    }
}

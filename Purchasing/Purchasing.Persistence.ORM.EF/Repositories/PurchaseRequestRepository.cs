using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseRequestRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseRequest, System.Guid>
    {
        public PurchaseRequestRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.PurchaseRequest> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.UnitMeasurement);
        }
    }
}

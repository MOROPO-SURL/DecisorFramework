using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseReceptionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.PurchaseReception, System.Guid>
    {
        public PurchaseReceptionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Persistence.Entities.PurchaseReception> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.ProductWeightBridges).ThenInclude(bridge => bridge.Product).ThenInclude(entity => entity.UnitMeasurement);
        }
    }
}

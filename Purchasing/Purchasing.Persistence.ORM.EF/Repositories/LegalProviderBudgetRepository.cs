using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class LegalProviderBudgetRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalProviderBudget, System.Guid>
    {
        public LegalProviderBudgetRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.LegalProviderBudget> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Provider).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Provider).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Commercial).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Classification)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Currenty)
                .Include(entity => entity.ServiceBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ServiceBridges).ThenInclude(bridge => bridge.Currenty);
        }
    }
}

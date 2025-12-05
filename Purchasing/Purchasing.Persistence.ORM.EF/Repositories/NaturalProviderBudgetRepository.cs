using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class NaturalProviderBudgetRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalProviderBudget, System.Guid>
    {
        public NaturalProviderBudgetRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalProviderBudget> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Provider).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Provider).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Commercial).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.BudgetProducts).ThenInclude(bridge => bridge.Product).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.BudgetProducts).ThenInclude(bridge => bridge.Classification)
                .Include(entity => entity.BudgetProducts).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.BudgetProducts).ThenInclude(bridge => bridge.Currenty)
                .Include(entity => entity.ServiceBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ServiceBridges).ThenInclude(bridge => bridge.Currenty)
                .Include(entity => entity.Document);
        }
    }
}

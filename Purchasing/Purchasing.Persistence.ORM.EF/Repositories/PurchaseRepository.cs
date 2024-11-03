using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Purchase, System.Guid>
    {
        public PurchaseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Purchase> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Zone)
                .Include(entity => entity.Purchaser).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.LegalProviderProductBridges).ThenInclude(bridge => bridge.Product).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.LegalProviderProductBridges).ThenInclude(bridge => bridge.Provider).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.LegalProviderProductBridges).ThenInclude(bridge => bridge.Provider).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.LegalProviderProductBridges).ThenInclude(bridge => bridge.CostCenter)
                .Include(entity => entity.LegalProviderProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.NaturalProviderProductBridges).ThenInclude(bridge => bridge.Product).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.NaturalProviderProductBridges).ThenInclude(bridge => bridge.Provider).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.NaturalProviderProductBridges).ThenInclude(bridge => bridge.Provider).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.NaturalProviderProductBridges).ThenInclude(bridge => bridge.CostCenter)
                .Include(entity => entity.NaturalProviderProductBridges).ThenInclude(bridge => bridge.UnitMeasurement)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ColaboratorBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.SpentBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Reception);
        }

        public override System.Func<Persistence.Entities.Purchase, object> GetPagingOrderSelector()
        {
            return entity => entity.At;
        }
    }
}

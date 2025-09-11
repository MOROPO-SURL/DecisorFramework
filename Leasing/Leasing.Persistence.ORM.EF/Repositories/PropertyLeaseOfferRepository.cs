using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class PropertyLeaseOfferRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeaseOffer, System.Guid>
    {
        public PropertyLeaseOfferRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.PropertyLeaseOffer> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Agreement)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Property).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Property).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

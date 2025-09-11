using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class VehicleLeaseOfferRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public VehicleLeaseOfferRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.VehicleLeaseOffer> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Agreement)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.Brand)
                .Include(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

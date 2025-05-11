using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class VehicleLeaseOfferRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public VehicleLeaseOfferRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.VehicleLeaseOffer> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Vehicle).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.OrganizationPostulations).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.PersonPostulations).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}

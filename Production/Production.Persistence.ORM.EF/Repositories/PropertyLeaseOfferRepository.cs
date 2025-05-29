using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class PropertyLeaseOfferRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeaseOffer, System.Guid>
    {
        public PropertyLeaseOfferRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.PropertyLeaseOffer> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Property).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.OrganizationPostulations).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.PersonPostulations).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}

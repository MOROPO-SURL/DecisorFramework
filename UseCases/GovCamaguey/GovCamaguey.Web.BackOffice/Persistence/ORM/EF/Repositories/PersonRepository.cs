using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories
{
    public class PersonRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.Person, System.Guid>
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Prototype.Persistence.Entities.Person> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Location)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.PhoneContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.EmailContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.WebSiteContactItemBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

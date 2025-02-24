using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class PersonContactRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<PersonContact, System.Guid>
    {
        public PersonContactRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<PersonContact> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Location);
        }
    }
}

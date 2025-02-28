using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Legal.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class ProformaRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Proforma, System.Guid>
    {
        public ProformaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Proforma> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Section)
                .Include(entity => entity.ClauseBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.CachedDocument)
                .Include(entity => entity.RawDocument);
        }
    }
}

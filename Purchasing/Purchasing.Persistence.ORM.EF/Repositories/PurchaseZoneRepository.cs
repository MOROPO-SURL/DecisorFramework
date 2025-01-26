using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
    public class PurchaseZoneRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PurchaseZone, System.Guid>
    {
        public PurchaseZoneRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.PurchaseZone> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.SpentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class PropertyLeasePersonPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeasePersonPostulation, System.Guid>
    {
        public PropertyLeasePersonPostulationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.PropertyLeasePersonPostulation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.BusinessKind)
                .Include(entity => entity.PropertySpaceBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.PropertySpace).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

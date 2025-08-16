using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class PropertyLeaseOrganizationPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeaseOrganizationPostulation, System.Guid>
    {
        public PropertyLeaseOrganizationPostulationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.PropertyLeaseOrganizationPostulation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.PropertySpaceBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.PropertySpace).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

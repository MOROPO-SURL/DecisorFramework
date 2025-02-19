using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class PropertyRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Property, System.Guid>
    {
        public PropertyRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Property> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.FeatureImage)
                .Include(entity => entity.Kind)
                .Include(entity => entity.PostalContact).ThenInclude(entity => entity.Location)
                .Include(entity => entity.ImageBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

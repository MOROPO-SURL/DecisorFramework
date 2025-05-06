using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class VehicleRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Vehicle, System.Guid>
    {
        public VehicleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Vehicle> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.FeatureImage)
                .Include(entity => entity.Kind)
                .Include(entity => entity.Brand)
                .Include(entity => entity.EngineKind)
                .Include(entity => entity.ImageBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

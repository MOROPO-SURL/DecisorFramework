using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class TechniqueRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Technique, System.Guid>
    {
        public TechniqueRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Technique> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.CubanStandardBridge).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.IsoStandardBridge).ThenInclude(bridge => bridge.Stern);
        }
    }
}

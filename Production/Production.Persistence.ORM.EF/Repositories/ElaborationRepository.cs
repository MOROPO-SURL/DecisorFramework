using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ElaborationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Elaboration, System.Guid>
    {
        public ElaborationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Elaboration> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Product).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.InputProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.OutputProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement);
        }
    }
}


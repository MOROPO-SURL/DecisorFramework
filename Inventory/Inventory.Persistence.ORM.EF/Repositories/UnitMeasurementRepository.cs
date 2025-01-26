using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class UnitMeasurementRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.UnitMeasurement, System.Guid>
    {
        public UnitMeasurementRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.UnitMeasurement> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.ConversionBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

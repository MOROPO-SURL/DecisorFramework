using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ProductionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Production, System.Guid>
    {
        public ProductionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Production> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .AsSplitQuery()
                .Include(entity => entity.Order).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Product).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.Order).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Steps).ThenInclude(entity => entity.WorkPositionBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Order).ThenInclude(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ProductBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Step).ThenInclude(entity => entity.WorkPositionBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.WorkPosition);
        }
    }
}


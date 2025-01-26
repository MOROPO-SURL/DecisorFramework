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
                .Include(entity => entity.Plan).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Product).ThenInclude(entity => entity.UnitMeasurement)
                .Include(entity => entity.Plan.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}


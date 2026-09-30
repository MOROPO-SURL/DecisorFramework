using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Repositories;

public sealed class ProductionQualityCheckRepository : AbstractEntityRepository<Entities.ProductionQualityCheck, System.Guid>
{
    public ProductionQualityCheckRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Entities.ProductionQualityCheck> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Production).ThenInclude(entity => entity.Order).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Product)
            .Include(entity => entity.Production).ThenInclude(entity => entity.UnitMeasurement);
    }
}
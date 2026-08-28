using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public class ProductionSampleRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProductionSample, System.Guid>
{
    public ProductionSampleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ProductionSample> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.FeatureImage)
            .Include(entity => entity.SampleKind)
            .Include(entity => entity.UnitMeasurement)
            .Include(entity => entity.Production).ThenInclude(entity => entity.Order).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Product)
            .Include(entity => entity.Production).ThenInclude(entity => entity.Order).ThenInclude(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity);
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public class ServiceOrderSampleRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ServiceOrderSample, System.Guid>
{
    public ServiceOrderSampleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ServiceOrderSample> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.FeatureImage)
            .Include(entity => entity.SampleKind)
            .Include(entity => entity.UnitMeasurement)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Service)
            .Include(entity => entity.Order).ThenInclude(entity => entity.RequestedTechnique);
    }
}

using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public sealed class AssessmentQualityCheckRepository : AbstractEntityRepository<AssessmentQualityCheck, System.Guid>
{
    public AssessmentQualityCheckRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<AssessmentQualityCheck> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Assessment).ThenInclude(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Assessment).ThenInclude(entity => entity.WorkPlan).ThenInclude(entity => entity.WorkingGroup)
            .Include(entity => entity.Assessment).ThenInclude(entity => entity.Sample).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.Assessment).ThenInclude(entity => entity.Sample).ThenInclude(entity => entity.UnitMeasurement);
    }
}

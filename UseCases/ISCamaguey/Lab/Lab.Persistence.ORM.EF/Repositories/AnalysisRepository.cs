using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public sealed class AnalysisRepository : AbstractEntityRepository<Analysis, System.Guid>
{
    public AnalysisRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Analysis> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.WorkPlan)
            .Include(entity => entity.Technique)
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Sample).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.Sample).ThenInclude(entity => entity.UnitMeasurement);
    }
}

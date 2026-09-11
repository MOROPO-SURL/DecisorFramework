using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public sealed class AssessmentRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Assessment, System.Guid>
{
    public AssessmentRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.Assessment> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.WorkPlan).ThenInclude(entity => entity.WorkingGroup)
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Sample).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.Sample).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Document);
    }
}
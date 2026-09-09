using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public class ResearchSampleRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ResearchSample, System.Guid>
{
    public ResearchSampleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ResearchSample> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.FeatureImage)
            .Include(entity => entity.SampleKind)
            .Include(entity => entity.UnitMeasurement)
            .Include(entity => entity.Project).ThenInclude(entity => entity.InternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.Project).ThenInclude(entity => entity.ExternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity);
    }
}
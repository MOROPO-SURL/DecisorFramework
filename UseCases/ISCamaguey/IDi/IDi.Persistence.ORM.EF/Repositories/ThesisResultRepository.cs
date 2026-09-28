using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ThesisResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ThesisResult, System.Guid>
{
    public ThesisResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ThesisResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Project)
            .Include(entity => entity.Document)
            .Include(entity => entity.InternalResearcherBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.ExternalResearcherBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
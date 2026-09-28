using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class PublicationResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PublicationResult, System.Guid>
{
    public PublicationResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.PublicationResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Project)
            .Include(entity => entity.Document)
            .Include(entity => entity.InternalResearcherBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.ExternalResearcherBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
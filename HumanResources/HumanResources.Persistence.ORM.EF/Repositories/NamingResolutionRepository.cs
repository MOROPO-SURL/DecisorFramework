using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class NamingResolutionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NamingResolution, System.Guid>
{
    public NamingResolutionRepository(DbContext dbContext) : base(dbContext) { }

    protected override IQueryable<Entities.NamingResolution> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.AdmitionPropousal).ThenInclude(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.AdmitionPropousal).ThenInclude(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Staff).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.AdmitionPropousal).ThenInclude(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
            .Include(entity => entity.AdmitionPropousal).ThenInclude(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
            .AsNoTracking()
            .AsSplitQuery();
    }
}
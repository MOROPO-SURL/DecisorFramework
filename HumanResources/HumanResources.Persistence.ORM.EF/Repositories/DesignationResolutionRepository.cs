using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class DesignationResolutionRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.DesignationResolution, System.Guid>
{
    public DesignationResolutionRepository(DbContext dbContext) : base(dbContext) { }

    protected override IQueryable<Entities.DesignationResolution> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
            .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
            .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup)
            .AsNoTracking()
            .AsSplitQuery();
    }
}
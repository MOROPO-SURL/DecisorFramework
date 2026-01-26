using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;

public class PropertyLeasePropousalRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeasePropousal, System.Guid>
{
    public PropertyLeasePropousalRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.PropertyLeasePropousal> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.BaselineCurrency)
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.Property).ThenInclude(entity => entity.FeatureImage)
            .Include(entity => entity.Property).ThenInclude(entity => entity.Kind)
            .Include(entity => entity.Property).ThenInclude(entity => entity.Spaces).ThenInclude(entity => entity.FeatureImage);
    }
}

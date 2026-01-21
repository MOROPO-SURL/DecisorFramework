using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;

public class PropertySpaceLeasePropousalRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertySpaceLeasePropousal, System.Guid>
{
    public PropertySpaceLeasePropousalRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.PropertySpaceLeasePropousal> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.PropertySpace).ThenInclude(entity => entity.FeatureImage);
    }
}

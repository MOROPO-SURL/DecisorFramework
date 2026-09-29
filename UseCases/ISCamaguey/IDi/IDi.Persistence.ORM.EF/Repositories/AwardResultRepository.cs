using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class AwardResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.AwardResult, System.Guid>
{
    public AwardResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.AwardResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Project)
            .Include(entity => entity.AwardKind)
            .Include(entity => entity.Receptor).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
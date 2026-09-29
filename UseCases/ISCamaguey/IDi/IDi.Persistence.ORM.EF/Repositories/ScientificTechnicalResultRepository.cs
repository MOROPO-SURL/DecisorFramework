using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ScientificTechnicalResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ScientificTechnicalResult, System.Guid>
{
    public ScientificTechnicalResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ScientificTechnicalResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Project)
            .Include(entity => entity.Kind);
    }
}
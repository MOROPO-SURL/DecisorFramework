using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories;

public class LegalClientTrainingServiceExecutionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientTrainingServiceExecution, System.Guid>
{
    public LegalClientTrainingServiceExecutionRepository(DbContext dbContext) : base(dbContext)
    {
    }
    protected override System.Linq.IQueryable<Entities.LegalClientTrainingServiceExecution> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Document)
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Service)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
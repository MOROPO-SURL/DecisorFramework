using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories;

public sealed class LegalClientSampleAnalysisServiceExecutionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientSampleAnalysisServiceExecution, System.Guid>
{
    public LegalClientSampleAnalysisServiceExecutionRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.LegalClientSampleAnalysisServiceExecution> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Document)
            .Include(entity => entity.Author).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Service)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
            .Include(entity => entity.Order).ThenInclude(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}
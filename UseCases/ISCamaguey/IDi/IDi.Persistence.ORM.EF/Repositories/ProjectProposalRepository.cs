using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ProjectProposalRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProjectProposal, System.Guid>
{
    public ProjectProposalRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.ProjectProposal> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Program).ThenInclude(entity => entity.ExpectResults)
            .Include(entity => entity.CallForPropousal).ThenInclude(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Document);
    }
}

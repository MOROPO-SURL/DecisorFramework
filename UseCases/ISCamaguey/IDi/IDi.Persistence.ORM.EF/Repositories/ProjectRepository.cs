using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ProjectRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Project, System.Guid>
{
    public ProjectRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Entities.Project> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Category)
            .Include(entity => entity.Document)
            .Include(entity => entity.Proposal)
            .Include(entity => entity.Predecessor)
            .Include(entity => entity.Chief).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Chief).ThenInclude(entity => entity.Category)
            .Include(entity => entity.Chief).ThenInclude(entity => entity.TeachingCategory)
            .Include(entity => entity.Program).ThenInclude(entity => entity.Kind)
            .Include(entity => entity.Program).ThenInclude(entity => entity.ExpectResults)
            .Include(entity => entity.ProgramExpectResultBridges).ThenInclude(entity => entity.Stern)
            .Include(entity => entity.SpecificObjectives)
            .Include(entity => entity.BudgetFunancings).ThenInclude(entity => entity.Currency)
            .Include(entity => entity.BudgetFunancings).ThenInclude(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.ParticipatingOrganizationBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.ParticipatingOrganizationBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
            .Include(entity => entity.InternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.InternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Category)
            .Include(entity => entity.InternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.TeachingCategory)
            .Include(entity => entity.ExternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.ExternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Category)
            .Include(entity => entity.ExternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.TeachingCategory);
    }
}
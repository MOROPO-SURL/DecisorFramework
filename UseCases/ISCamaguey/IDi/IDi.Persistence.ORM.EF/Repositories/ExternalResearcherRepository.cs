using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class ExternalResearcherRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ExternalResearcher, System.Guid>
    {
        public ExternalResearcherRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ExternalResearcher> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ParticipatingOrganization).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ParticipatingOrganization).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Category)
                .Include(entity => entity.TeachingCategory)
                .Include(entity => entity.ResearchAreaDoctorateBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaMasteryBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaSpecializationBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

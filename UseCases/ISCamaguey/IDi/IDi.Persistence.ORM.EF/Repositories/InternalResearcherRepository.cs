using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class InternalResearcherRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.InternalResearcher, System.Guid>
    {
        public InternalResearcherRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.InternalResearcher> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Category)
                .Include(entity => entity.TeachingCategory)
                .Include(entity => entity.ResearchAreaDoctorateBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaMasteryBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaSpecializationBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

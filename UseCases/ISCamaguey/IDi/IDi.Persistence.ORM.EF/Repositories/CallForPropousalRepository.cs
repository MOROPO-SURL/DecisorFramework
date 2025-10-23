using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class CallForPropousalRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CallForPropousal, System.Guid>
    {
        public CallForPropousalRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.CallForPropousal> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.ResearchAreaBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

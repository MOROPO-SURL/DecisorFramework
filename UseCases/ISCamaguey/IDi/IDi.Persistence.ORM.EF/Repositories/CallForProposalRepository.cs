using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class CallForProposalRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CallForProposal, System.Guid>
    {
        public CallForProposalRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.CallForProposal> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Financier).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.KnowledgeAreaBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

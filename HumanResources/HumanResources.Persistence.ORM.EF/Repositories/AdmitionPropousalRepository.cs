using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class AdmitionPropousalRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.AdmitionPropousal, System.Guid>
    {
        public AdmitionPropousalRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.AdmitionPropousal> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Staff).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
                .Include(entity => entity.OcupationCandidate).ThenInclude(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup);
        }
    }
}

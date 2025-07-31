using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories
{
    public class DecisionMakingGroupRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.DecisionMakingGroup, System.Guid>
    {
        public DecisionMakingGroupRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<DecisionMakingGroup> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Structure).ThenInclude(entity => entity.Identity);
        }
    }
}

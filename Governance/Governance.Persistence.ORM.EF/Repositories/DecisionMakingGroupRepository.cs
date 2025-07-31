using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories
{
    public class DecisionMakingGroupRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.DecisionMakingGroup, System.Guid>
    {
        public DecisionMakingGroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

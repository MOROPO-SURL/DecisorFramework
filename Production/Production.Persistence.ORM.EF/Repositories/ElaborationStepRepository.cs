using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Repositories
{
    public class ElaborationStepRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ElaborationStep, System.Guid>
    {
        public ElaborationStepRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ElaborationStep> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.ProductionRoleBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

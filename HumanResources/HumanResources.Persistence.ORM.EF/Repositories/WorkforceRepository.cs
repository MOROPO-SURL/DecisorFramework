using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class WorkforceRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Workforce, System.Guid>
    {
        public WorkforceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Workforce> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.OrganizationalUnityBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
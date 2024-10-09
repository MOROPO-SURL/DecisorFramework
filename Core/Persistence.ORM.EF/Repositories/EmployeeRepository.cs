using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Repositories
{
    public class EmployeeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Employee, System.Guid>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Entities.Employee> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.EmailContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.PhoneContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity).ThenInclude(entity => entity.WebSiteContactItemBridges).ThenInclude(bridge => bridge.Stern);
        }

        public override System.Func<Entities.Employee, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}

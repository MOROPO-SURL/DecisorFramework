using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories
{
    public class MeetingRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Meeting, System.Guid>
    {
        public MeetingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Meeting> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Author).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ContactBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
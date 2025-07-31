using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories
{
    public class MeetingRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Meeting, System.Guid>
    {
        public MeetingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
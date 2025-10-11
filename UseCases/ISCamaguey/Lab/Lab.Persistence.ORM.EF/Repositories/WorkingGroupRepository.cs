using Microsoft.EntityFrameworkCore;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories
{
    public class WorkingGroupRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WorkingGroup, System.Guid>
    {
        public WorkingGroupRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<WorkingGroup> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Chief).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.QualitySpecialist).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.TechniqueBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

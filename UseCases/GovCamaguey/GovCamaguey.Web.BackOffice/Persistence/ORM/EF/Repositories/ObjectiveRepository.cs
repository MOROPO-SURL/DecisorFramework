using Microsoft.EntityFrameworkCore;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories
{
    public class ObjectiveRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.Objective, System.Guid>
    {
        public ObjectiveRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Objective> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Proyections);
        }
    }
}

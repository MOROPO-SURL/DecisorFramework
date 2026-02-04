using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class OcupationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Ocupation, System.Guid>
    {
        public OcupationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.Ocupation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Staff).ThenInclude(entity => entity.MainWorkforce)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}

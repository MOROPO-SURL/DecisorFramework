using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class OcupationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Ocupation, System.Guid>
    {
        public OcupationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Ocupation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Employee).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}

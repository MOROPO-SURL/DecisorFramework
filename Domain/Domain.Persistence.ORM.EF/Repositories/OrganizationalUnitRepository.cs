using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class OrganizationalUnitRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationalUnit, System.Guid>
    {
        public OrganizationalUnitRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<OrganizationalUnit> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().AsNoTracking();
        }
    }
}

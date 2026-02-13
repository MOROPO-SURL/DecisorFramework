using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class OrganizationalUnityRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationalUnity, System.Guid>
    {
        public OrganizationalUnityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<OrganizationalUnity> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().AsNoTracking();
        }
    }
}

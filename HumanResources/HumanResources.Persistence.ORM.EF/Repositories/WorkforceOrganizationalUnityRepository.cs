using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class WorkforceOrganizationalUnityRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WorkforceOrganizationalUnity, System.Guid>
    {
        public WorkforceOrganizationalUnityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<WorkforceOrganizationalUnity> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.OrganizationalUnity)
                .Include(entity => entity.ChiefVacant);
        }
    }
}

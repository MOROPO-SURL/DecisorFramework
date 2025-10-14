using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class NamingEmploymentContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NamingEmploymentContract, int>
    {
        public NamingEmploymentContractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NamingEmploymentContract> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkforceOrganizationalUnity).ThenInclude(entity => entity.OrganizationalUnity)
                .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.Staff).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Resolution).ThenInclude(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup);
        }
    }
}

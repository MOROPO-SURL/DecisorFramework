using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class AdmitionEmploymentContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.AdmitionEmploymentContract, System.Guid>
    {
        public AdmitionEmploymentContractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.AdmitionEmploymentContract> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkforceOrganizationalUnit).ThenInclude(entity => entity.OrganizationalStructuringUnit)
                .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition).ThenInclude(entity => entity.Kind)
                .Include(entity => entity.Staff).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.AdmitionPropousal);
        }
    }
}

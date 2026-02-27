using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class NamingEmploymentContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NamingEmploymentContract, System.Guid>
{
    public NamingEmploymentContractRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.NamingEmploymentContract> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkforceOrganizationalUnit).ThenInclude(entity => entity.OrganizationalStructuringUnit).ThenInclude(entity => entity.OrganizationalUnit)
            .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition).ThenInclude(entity => entity.Kind)
            .Include(entity => entity.Staff).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.Resolution).ThenInclude(entity => entity.Agreement).ThenInclude(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup)
            .AsSplitQuery();
    }
}

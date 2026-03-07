using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class WorkforceOrganizationalUnitRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WorkforceOrganizationalUnit, System.Guid>
{
    public WorkforceOrganizationalUnitRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<WorkforceOrganizationalUnit> GetQueryableDbSet()
    {
        // Is mandatory that no mark with AsNoTracking !!!
        return base.GetQueryableDbSet()
            .Include(entity => entity.OrganizationalStructuringUnit).ThenInclude(entity => entity.OrganizationalUnit)
            .Include(entity => entity.ChiefVacant).ThenInclude(entity => entity.WorkPosition)
            .Include(entity => entity.ChiefVacant).ThenInclude(entity => entity.SalaryStandard)
            .AsSplitQuery();
    }
}
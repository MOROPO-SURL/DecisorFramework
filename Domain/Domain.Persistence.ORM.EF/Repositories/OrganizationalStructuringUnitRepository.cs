using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class OrganizationalStructuringUnitRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationalStructuringUnit, System.Guid>
{
    public OrganizationalStructuringUnitRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.OrganizationalStructuringUnit> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().Include(entity => entity.OrganizationalUnit);
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class StaffRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Staff, System.Guid>
{
    public StaffRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.Staff> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.MainWorkforce)
            .Include(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.OrganizationalStructure)
            .Include(entity => entity.AlternativeWorkforceBridges).ThenInclude(bridge => bridge.Stern)
            .AsSplitQuery();
    }
}

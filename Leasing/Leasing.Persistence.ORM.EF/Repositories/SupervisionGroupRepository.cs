using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories;

public class SupervisionGroupRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.SupervisionGroup, System.Guid>
{
    public SupervisionGroupRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<SupervisionGroup> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Representative).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}

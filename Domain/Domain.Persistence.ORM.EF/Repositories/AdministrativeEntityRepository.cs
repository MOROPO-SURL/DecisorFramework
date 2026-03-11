using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class AdministrativeEntityRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.AdministrativeEntity, System.Guid>
{
    public AdministrativeEntityRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.AdministrativeEntity> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Kind)
            .Include(entity => entity.OrganizationalStructure).ThenInclude(bridge => bridge.RootStructuringUnit);
    }
}

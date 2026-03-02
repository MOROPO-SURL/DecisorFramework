using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class OrganizationalStructureRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationalStructure, System.Guid>
{
    public OrganizationalStructureRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.OrganizationalStructure> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.RootStructuringUnit).ThenInclude(entity => entity.OrganizationalUnit);
    }
}
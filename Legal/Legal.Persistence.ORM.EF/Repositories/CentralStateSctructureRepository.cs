using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories;

public class CentralStateSctructureRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.CentralStateStructure, System.Guid>
{
    public CentralStateSctructureRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.CentralStateStructure> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().Include(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}

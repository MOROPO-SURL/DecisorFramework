using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ProyectionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.Proyection, System.Guid>
{
    public ProyectionRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.Proyection> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Objective)
            .AsNoTracking()
            .AsSplitQuery();
    }
}

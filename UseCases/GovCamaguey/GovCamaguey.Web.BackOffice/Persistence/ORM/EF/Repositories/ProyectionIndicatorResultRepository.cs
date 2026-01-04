using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ProyectionIndicatorResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ProyectionIndicatorResult, long>
{
    public ProyectionIndicatorResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ProyectionIndicatorResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.Proyection).ThenInclude(entity => entity.Objective)
            .AsSplitQuery();
    }
}

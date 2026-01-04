using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ObjectiveIndicatorResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ObjectiveIndicatorResult, long>
{
    public ObjectiveIndicatorResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ObjectiveIndicatorResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.Objective)
            .AsSplitQuery();
    }
}

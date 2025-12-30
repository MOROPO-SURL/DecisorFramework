using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ActionIndicatorResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ActionIndicatorResult, long>
{
    public ActionIndicatorResultRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ActionIndicatorResult> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Indicator).ThenInclude(entity => entity.Action).ThenInclude(entity => entity.Proyection).ThenInclude(entity => entity.Objective)
            .AsSplitQuery();
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ActionIndicatorRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ActionIndicator, System.Guid>
{
    public ActionIndicatorRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ActionIndicator> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            //.AsNoTracking()
            .Include(entity => entity.UnitMeasurement)
            .Include(entity => entity.Action).ThenInclude(entity => entity.Proyection).ThenInclude(entity => entity.Objective);
    }
}

using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class GlobalIndicatorRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.GlobalIndicator, System.Guid>
{
    public GlobalIndicatorRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.GlobalIndicator> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsNoTracking()
            .Include(entity => entity.UnitMeasurement)
            .Include(entity => entity.MontlyPlans);
    }
}

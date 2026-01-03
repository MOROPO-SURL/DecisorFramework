using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ProyectionIndicatorMontlyPlanRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ProyectionIndicatorMontlyPlan, System.Guid>
{
    public ProyectionIndicatorMontlyPlanRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ProyectionIndicatorMontlyPlan> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().AsNoTracking();
    }
}

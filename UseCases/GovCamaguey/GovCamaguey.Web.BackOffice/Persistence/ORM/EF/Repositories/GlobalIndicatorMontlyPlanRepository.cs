using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class GlobalIndicatorMontlyPlanRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.GlobalIndicatorMontlyPlan, System.Guid>
{
    public GlobalIndicatorMontlyPlanRepository(DbContext dbContext) : base(dbContext)
    {
    }

    //protected override System.Linq.IQueryable<Prototype.Persistence.Entities.GlobalIndicatorMontlyPlan> GetQueryableDbSet()
    //{
    //    return base.GetQueryableDbSet().AsNoTracking();
    //}
}
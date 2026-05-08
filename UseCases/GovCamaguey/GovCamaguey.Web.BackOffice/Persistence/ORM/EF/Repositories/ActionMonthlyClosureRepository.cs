using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ActionMonthlyClosureRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.ActionMonthlyClosure, System.Guid>
{
    public ActionMonthlyClosureRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }

    //protected override System.Linq.IQueryable<Prototype.Persistence.Entities.ActionMonthlyClosure> GetQueryableDbSet()
    //{
    //    return base.GetQueryableDbSet().AsNoTracking();
    //}
}

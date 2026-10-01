using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.ORM.EF.Repositories;

public sealed class RecomendationReportRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.RecomendationReport, System.Guid>
{
    public RecomendationReportRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Entities.RecomendationReport> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Document)
            .Include(entity => entity.EmployeeBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
    }
}

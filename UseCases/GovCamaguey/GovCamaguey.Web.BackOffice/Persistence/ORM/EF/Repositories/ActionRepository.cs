using Microsoft.EntityFrameworkCore;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Repositories;

public class ActionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Prototype.Persistence.Entities.Action, System.Guid>
{
    public ActionRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<Prototype.Persistence.Entities.Action> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            //.AsNoTracking()
            .Include(entity => entity.Proyection).ThenInclude(entity => entity.Objective)
            .Include(entity => entity.OrganizationResponsabilityBridges)
            .Include(entity => entity.OrganizationParticipationBridges)
            .Include(entity => entity.MonthlyClosures)
            .Include(entity => entity.Indicators).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Indicators).ThenInclude(entity => entity.MontlyPlans);
    }
}

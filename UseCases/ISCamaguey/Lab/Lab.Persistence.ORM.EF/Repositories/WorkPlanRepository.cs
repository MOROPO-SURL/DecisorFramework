using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public sealed class WorkPlanRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.WorkPlan, System.Guid>
{
    public WorkPlanRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Entities.WorkPlan> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.WorkingGroup)
            .Include(entity => entity.ServiceOrderSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.ServiceOrderSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.ServiceOrderSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Order).ThenInclude(entity => entity.Service)
            .Include(entity => entity.ResearchSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.ResearchSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.ResearchSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Project).ThenInclude(entity => entity.ExternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.ResearchSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Project).ThenInclude(entity => entity.InternalResearcherParticipations).ThenInclude(entity => entity.Researcher).ThenInclude(entity => entity.Employee).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity)
            .Include(entity => entity.ProductionSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.ProductionSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.SampleKind)
            .Include(entity => entity.ProductionSampleBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Production).ThenInclude(entity => entity.Order).ThenInclude(entity => entity.Elaboration).ThenInclude(entity => entity.Product);
    }
}

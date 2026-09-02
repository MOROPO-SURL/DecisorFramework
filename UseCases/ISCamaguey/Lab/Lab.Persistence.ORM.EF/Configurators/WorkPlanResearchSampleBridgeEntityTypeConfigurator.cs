using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

public sealed class WorkPlanResearchSampleBridgeEntityTypeConfigurator : AbstractBridgeEntityTypeConfigurator<WorkPlanResearchSampleBridge, WorkPlan, System.Guid, ResearchSample, System.Guid>
{
    public WorkPlanResearchSampleBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = bridge => bridge.ResearchSampleBridges;
    }
}
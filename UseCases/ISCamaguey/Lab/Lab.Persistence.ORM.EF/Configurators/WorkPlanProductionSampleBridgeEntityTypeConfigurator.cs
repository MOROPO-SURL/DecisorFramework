using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

public sealed class WorkPlanProductionSampleBridgeEntityTypeConfigurator : AbstractBridgeEntityTypeConfigurator<WorkPlanProductionSampleBridge, WorkPlan, System.Guid, ProductionSample, System.Guid>
{
    public WorkPlanProductionSampleBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = bridge => bridge.ProductionSampleBridges;
    }
}

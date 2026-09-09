using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

public sealed class WorkPlanServiceOrderSampleBridgeEntityTypeConfigurator : AbstractBridgeEntityTypeConfigurator<WorkPlanServiceOrderSampleBridge, WorkPlan, System.Guid, ServiceOrderSample, System.Guid>
{
    public WorkPlanServiceOrderSampleBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = bridge => bridge.ServiceOrderSampleBridges;
    }
}
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.ORM.EF.Configurators;

public sealed class RecomendationReportEmployeeBridgeEntityTypeConfigurator : AbstractBridgeEntityTypeConfigurator<RecomendationReportEmployeeBridge, RecomendationReport, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
{
    public RecomendationReportEmployeeBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.EmployeeBridges;
    }
}

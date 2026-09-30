using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class ScientificTechnicalResultIntroductionEmployeeBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ScientificTechnicalResultIntroductionEmployeeBridge, Entities.ScientificTechnicalResultIntroduction, System.Guid, Employee, System.Guid>
{
    public ScientificTechnicalResultIntroductionEmployeeBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.EmployeeBridges;
    }
}
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class ProjectProgramExpectResultBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ProjectProgramExpectResultBridge, Project, System.Guid, ProgramExpectResult, System.Guid>
{
    public ProjectProgramExpectResultBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.ProgramExpectResultBridges;
    }
}

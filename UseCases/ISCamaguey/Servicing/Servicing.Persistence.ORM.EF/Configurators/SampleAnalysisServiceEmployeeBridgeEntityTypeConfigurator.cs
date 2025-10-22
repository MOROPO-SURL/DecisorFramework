namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class SampleAnalysisServiceEmployeeBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.SampleAnalysisServiceEmployeeBridge, Entities.SampleAnalysisService, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public SampleAnalysisServiceEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}

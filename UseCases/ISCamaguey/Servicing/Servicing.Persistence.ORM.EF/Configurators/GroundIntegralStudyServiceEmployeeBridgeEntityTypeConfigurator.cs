namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class GroundIntegralStudyServiceEmployeeBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.GroundIntegralStudyServiceEmployeeBridge, Entities.GroundIntegralStudyService, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public GroundIntegralStudyServiceEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}

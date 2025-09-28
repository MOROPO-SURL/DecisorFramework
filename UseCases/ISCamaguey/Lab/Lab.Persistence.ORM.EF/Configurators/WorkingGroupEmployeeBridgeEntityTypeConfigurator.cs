namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators
{
    public class WorkingGroupEmployeeBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.WorkingGroupEmployeeBridge, Entities.WorkingGroup, System.Guid, Framework.Decisor.Domain.Persistence.Entities.Employee, System.Guid>
    {
        public WorkingGroupEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}
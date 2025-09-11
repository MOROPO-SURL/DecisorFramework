namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class SupervisionGroupsEmployeeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.SupervisionGroupEmployeeBridge, Entities.SupervisionGroup, System.Guid, Domain.Persistence.Entities.Employee, System.Guid>
    {
        public SupervisionGroupsEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}

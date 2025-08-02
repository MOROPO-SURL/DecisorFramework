namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class DecisionMakingGroupEmployeeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.DecisionMakingGroupEmployeeBridge, Entities.DecisionMakingGroup, System.Guid, HumanResources.Persistence.Entities.Employee, System.Guid>
    {
        public DecisionMakingGroupEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}

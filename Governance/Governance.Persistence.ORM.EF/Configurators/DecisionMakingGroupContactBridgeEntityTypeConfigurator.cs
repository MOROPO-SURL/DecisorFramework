namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class DecisionMakingGroupContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.DecisionMakingGroupContactBridge, Entities.DecisionMakingGroup, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public DecisionMakingGroupContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}

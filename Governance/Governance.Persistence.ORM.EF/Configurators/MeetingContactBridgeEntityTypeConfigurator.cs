namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class MeetingContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.MeetingContactBridge, Entities.Meeting, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public MeetingContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}

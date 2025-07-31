namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class MeetingDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.MeetingDocumentBridge, Entities.Meeting, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public MeetingDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalClientDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientDocumentBridge, Entities.LegalClient, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public LegalClientDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.DocumentBridges;
        }
    }
}

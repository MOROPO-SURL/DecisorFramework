namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalProviderDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalProviderDocumentBridge, Entities.LegalProvider, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public LegalProviderDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.DocumentBridges;
        }
    }
}
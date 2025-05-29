namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalProviderDocumentBridge, Entities.NaturalProvider, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public NaturalProviderDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.DocumentBridges;
        }
    }
}

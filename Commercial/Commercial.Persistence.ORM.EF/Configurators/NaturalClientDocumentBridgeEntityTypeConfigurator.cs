namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalClientDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientDocumentBridge, Entities.NaturalClient, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public NaturalClientDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.DocumentBridges;
        }
    }
}

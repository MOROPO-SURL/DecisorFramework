namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class CallForPropousalDocumentBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CallForPropousalDocumentBridge, Entities.CallForPropousal, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public CallForPropousalDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}

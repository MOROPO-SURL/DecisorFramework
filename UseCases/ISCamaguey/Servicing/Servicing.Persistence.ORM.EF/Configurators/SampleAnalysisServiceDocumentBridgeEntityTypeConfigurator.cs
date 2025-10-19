namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class SampleAnalysisServiceDocumentBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.SampleAnalysisServiceDocumentBridge, Entities.SampleAnalysisService, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public SampleAnalysisServiceDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}

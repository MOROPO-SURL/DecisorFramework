namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class TrainingServiceDocumentBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TrainingServiceDocumentBridge, Entities.TrainingService, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public TrainingServiceDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}

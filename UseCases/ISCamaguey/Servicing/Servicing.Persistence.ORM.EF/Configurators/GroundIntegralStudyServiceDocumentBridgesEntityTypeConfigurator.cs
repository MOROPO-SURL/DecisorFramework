namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class GroundIntegralStudyServiceDocumentBridgesEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.GroundIntegralStudyServiceDocumentBridge, Entities.GroundIntegralStudyService, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public GroundIntegralStudyServiceDocumentBridgesEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}

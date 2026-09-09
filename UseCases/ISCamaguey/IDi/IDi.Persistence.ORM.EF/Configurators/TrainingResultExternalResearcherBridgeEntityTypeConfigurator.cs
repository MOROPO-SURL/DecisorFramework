namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class TrainingResultExternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TrainingResultExternalResearcherBridge, Entities.TrainingResult, System.Guid, Entities.ExternalResearcher, System.Guid>
    {
        public TrainingResultExternalResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ExternalResearcherBridges;
        }
    }
}

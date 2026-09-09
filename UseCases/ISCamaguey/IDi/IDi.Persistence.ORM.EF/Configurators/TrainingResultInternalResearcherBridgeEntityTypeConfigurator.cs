namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class TrainingResultInternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TrainingResultInternalResearcherBridge, Entities.TrainingResult, System.Guid, Entities.InternalResearcher, System.Guid>
    {
        public TrainingResultInternalResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InternalResearcherBridges;
        }
    }
}

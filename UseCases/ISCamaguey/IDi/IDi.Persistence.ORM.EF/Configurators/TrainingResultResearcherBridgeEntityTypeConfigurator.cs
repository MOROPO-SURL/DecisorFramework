namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class TrainingResultResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TrainingResultResearcherBridge, Entities.TrainingResult, System.Guid, Entities.Contract.AbstractResearcher, System.Guid>
    {
        public TrainingResultResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearcherBridges;
        }
    }
}

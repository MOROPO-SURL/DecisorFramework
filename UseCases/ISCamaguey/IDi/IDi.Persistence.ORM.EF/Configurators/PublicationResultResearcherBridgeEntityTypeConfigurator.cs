namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class PublicationResultResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PublicationResultResearcherBridge, Entities.PublicationResult, System.Guid, Entities.Contract.AbstractResearcher, System.Guid>
    {
        public PublicationResultResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearcherBridges;
        }
    }
}

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ResearcherResearchAreaSpecializationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ResearcherResearchAreaSpecializationBridge, Entities.Contract.AbstractResearcher, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public ResearcherResearchAreaSpecializationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaSpecializationBridges;
        }
    }
}

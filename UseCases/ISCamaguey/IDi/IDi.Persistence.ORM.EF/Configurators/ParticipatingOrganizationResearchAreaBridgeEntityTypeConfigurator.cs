namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ParticipatingOrganizationResearchAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ParticipatingOrganizationResearchAreaBridge, Entities.ParticipatingOrganization, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public ParticipatingOrganizationResearchAreaBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaBridges;
        }
    }
}

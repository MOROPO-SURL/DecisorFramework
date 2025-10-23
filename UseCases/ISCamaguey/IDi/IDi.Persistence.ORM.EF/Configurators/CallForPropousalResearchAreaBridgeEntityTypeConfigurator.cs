namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class CallForPropousalResearchAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CallForPropousalResearchAreaBridge, Entities.CallForPropousal, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public CallForPropousalResearchAreaBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaBridges;
        }
    }
}

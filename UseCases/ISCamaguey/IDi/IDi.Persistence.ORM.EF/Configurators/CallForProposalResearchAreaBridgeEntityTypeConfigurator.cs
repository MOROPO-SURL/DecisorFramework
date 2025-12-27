namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class CallForProposalResearchAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CallForProposalResearchAreaBridge, Entities.CallForProposal, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public CallForProposalResearchAreaBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaBridges;
        }
    }
}

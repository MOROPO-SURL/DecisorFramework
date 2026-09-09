namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class CallForProposalKnowledgeAreaBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CallForProposalKnowledgeAreaBridge, Entities.CallForProposal, System.Guid, Framework.Decisor.Domain.Persistence.Entities.KnowledgeArea, System.Guid>
{
    public CallForProposalKnowledgeAreaBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.KnowledgeAreaBridges;
    }
}

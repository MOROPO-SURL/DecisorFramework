using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class CallForProposalKnowledgeAreaBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<CallForProposal, System.Guid, KnowledgeArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public CallForProposal Prow { get; set; }

        public System.Guid SternId { get; set; }
        public KnowledgeArea Stern { get; set; }
    }
}

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class CallForProposalResearchAreaBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<CallForProposal, System.Guid, ResearchArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public CallForProposal Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ResearchArea Stern { get; set; }
    }
}

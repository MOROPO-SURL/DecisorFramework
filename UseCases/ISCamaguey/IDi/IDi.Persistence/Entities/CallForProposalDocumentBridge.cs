namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class CallForProposalDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<CallForProposal, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public CallForProposal Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

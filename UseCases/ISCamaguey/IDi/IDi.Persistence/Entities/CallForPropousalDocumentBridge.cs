namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class CallForPropousalDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<CallForPropousal, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public CallForPropousal Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

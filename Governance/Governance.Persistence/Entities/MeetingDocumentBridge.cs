namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class MeetingDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Meeting, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Meeting Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

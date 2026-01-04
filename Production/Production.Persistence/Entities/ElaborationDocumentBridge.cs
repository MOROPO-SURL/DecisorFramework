namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Elaboration, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Elaboration Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

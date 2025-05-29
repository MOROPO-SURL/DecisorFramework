namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalClientDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClient, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClient Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

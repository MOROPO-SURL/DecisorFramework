namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeasePersonPostulationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeasePersonPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeasePersonPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

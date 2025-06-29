namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeasePersonPostulationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<VehicleLeasePersonPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public VehicleLeasePersonPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

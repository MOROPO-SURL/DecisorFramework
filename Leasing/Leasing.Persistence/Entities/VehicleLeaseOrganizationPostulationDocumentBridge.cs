namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeaseOrganizationPostulationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<VehicleLeaseOrganizationPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public VehicleLeaseOrganizationPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

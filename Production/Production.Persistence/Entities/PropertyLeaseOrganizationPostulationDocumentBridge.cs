namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class PropertyLeaseOrganizationPostulationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeaseOrganizationPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeaseOrganizationPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}
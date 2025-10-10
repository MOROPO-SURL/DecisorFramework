namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class VacantPostulationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<VacantPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public VacantPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

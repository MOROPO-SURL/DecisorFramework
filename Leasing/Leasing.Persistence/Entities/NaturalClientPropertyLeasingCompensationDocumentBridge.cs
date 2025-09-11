namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasingCompensationDocumentBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClientPropertyLeasingCompensation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClientPropertyLeasingCompensation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

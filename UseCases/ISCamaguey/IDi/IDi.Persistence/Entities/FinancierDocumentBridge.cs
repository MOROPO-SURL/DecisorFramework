namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class FinancierDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Financier, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Financier Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class SampleAnalysisServiceDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<SampleAnalysisService, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public SampleAnalysisService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

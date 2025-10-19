namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class TrainingServiceDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingService, System.Guid, Framework.Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public TrainingService Prow { get; set; }

        public System.Guid SternId { get; set; }
        public  Framework.Guama.Media.Persistence.Entities.Document Stern { get; set; }
    }
}

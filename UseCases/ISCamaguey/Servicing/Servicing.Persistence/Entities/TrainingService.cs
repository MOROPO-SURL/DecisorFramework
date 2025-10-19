namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class TrainingService : Contract.AbstractService
    {
        public System.Collections.Generic.ICollection<TrainingServiceStep> Steps { get; set; }

        public System.Collections.Generic.List<TrainingServiceDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<TrainingServiceDocumentBridge>();
    }
}
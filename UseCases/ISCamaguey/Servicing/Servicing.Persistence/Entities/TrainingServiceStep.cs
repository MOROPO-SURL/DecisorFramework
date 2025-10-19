namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class TrainingServiceStep : Contract.AbstractServiceStep
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServiceId))]
        public TrainingService Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public TrainingServiceStep Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        public System.Collections.Generic.List<TrainingServiceStepWorkPositionBridge> WorkPositionBridges { get; set; } = new System.Collections.Generic.List<TrainingServiceStepWorkPositionBridge>();
    }
}

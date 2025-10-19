namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class SampleAnalysisServiceStep : Contract.AbstractServiceStep
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServiceId))]
        public SampleAnalysisService Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public SampleAnalysisServiceStep Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        public System.Collections.Generic.List<SampleAnalysisServiceStepWorkPositionBridge> WorkPositionBridges { get; set; } = new System.Collections.Generic.List<SampleAnalysisServiceStepWorkPositionBridge>();
    }
}

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class GroundIntegralStudyServiceStep : Contract.AbstractServiceStep
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServiceId))]
        public GroundIntegralStudyService Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public GroundIntegralStudyServiceStep Parent { get; set; }
        public System.Guid? ParentId { get; set; }

        public System.Collections.Generic.List<GroundIntegralStudyServiceStepWorkPositionBridge> WorkPositionBridges { get; set; } = new System.Collections.Generic.List<GroundIntegralStudyServiceStepWorkPositionBridge>();
    }
}

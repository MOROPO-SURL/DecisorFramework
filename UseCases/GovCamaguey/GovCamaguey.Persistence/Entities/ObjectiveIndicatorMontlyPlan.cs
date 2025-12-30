namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class ObjectiveIndicatorMontlyPlan : Contract.AbstractIndicatorMontlyPlan
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(IndicatorId))]
        public ObjectiveIndicator Indicator { get; set; }
        public System.Guid IndicatorId { get; set; }
    }
}

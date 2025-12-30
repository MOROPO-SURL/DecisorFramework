namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class ActionIndicatorMontlyPlan : Contract.AbstractIndicatorMontlyPlan
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(IndicatorId))]
        public ActionIndicator Indicator { get; set; }
        public System.Guid IndicatorId { get; set; }
    }
}
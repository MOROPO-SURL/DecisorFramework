namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class IndicatorMontlyPlan : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(IndicatorId))]
        public Indicator Indicator { get; set; }
        public System.Guid IndicatorId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public double Amount { get; set; }
    }
}

namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Result : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public System.DateTime At { get; private set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(IndicatorId))]
        public Indicator Indicator { get; set; }
        public System.Guid IndicatorId { get; set; }

        public double Amount { get; set; }
    }
}

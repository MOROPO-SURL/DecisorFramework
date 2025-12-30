namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractIndicatorResult : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public System.DateTime At { get; private set; } = System.DateTime.Now;

        public double Amount { get; set; }
    }
}
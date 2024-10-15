namespace MOROPO.Framework.Decisor.Essential.Persistence.Entities
{
    public class UnitMeasurementConversionBridge : Guama.Core.Persistence.Entities.Contract.IBridge<UnitMeasurement, System.Guid, UnitMeasurement, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public UnitMeasurement Prow { get; set; }

        public System.Guid SternId { get; set; }
        public UnitMeasurement Stern { get; set; }

        public decimal Convertion { get; set; }
    }
}


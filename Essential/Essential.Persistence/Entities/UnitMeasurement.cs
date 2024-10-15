namespace MOROPO.Framework.Decisor.Essential.Persistence.Entities
{
	public class UnitMeasurement : Core.Persistence.Entities.Contract.AbstractNomenclator
	{
		public System.Collections.Generic.List<UnitMeasurementConversionBridge> ConversionBridges { get; set; } = new System.Collections.Generic.List<UnitMeasurementConversionBridge>();
	}
}


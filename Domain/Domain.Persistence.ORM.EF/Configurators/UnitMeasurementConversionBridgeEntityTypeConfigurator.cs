namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class UnitMeasurementConversionBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.UnitMeasurementConversionBridge, Entities.UnitMeasurement, System.Guid, Entities.UnitMeasurement, System.Guid>
	{
		public UnitMeasurementConversionBridgeEntityTypeConfigurator()
		{
			prowNavigationExpression = entity => entity.ConversionBridges;
		}
	}
}


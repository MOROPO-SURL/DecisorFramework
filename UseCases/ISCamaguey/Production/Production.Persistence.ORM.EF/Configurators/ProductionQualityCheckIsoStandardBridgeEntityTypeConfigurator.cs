namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionQualityCheckIsoStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionQualityCheckIsoStandardBridge, Entities.ProductionQualityCheck, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public ProductionQualityCheckIsoStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.IsoStandardBridge;
        }
    }
}
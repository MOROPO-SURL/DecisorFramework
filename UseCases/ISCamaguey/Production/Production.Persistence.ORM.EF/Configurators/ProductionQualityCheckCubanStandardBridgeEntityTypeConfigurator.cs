namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionQualityCheckCubanStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionQualityCheckCubanStandardBridge, Entities.ProductionQualityCheck, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public ProductionQualityCheckCubanStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CubanStandardBridge;
        }
    }
}
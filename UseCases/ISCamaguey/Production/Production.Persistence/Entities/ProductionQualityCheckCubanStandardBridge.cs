namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities
{
    public class ProductionQualityCheckCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ProductionQualityCheck, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public ProductionQualityCheck Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Quality.Persistence.Entities.CubanStandard Stern { get ; set ; }
    }
}

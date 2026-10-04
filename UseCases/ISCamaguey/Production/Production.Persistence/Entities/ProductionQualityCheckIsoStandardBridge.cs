namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities
{
    public class ProductionQualityCheckIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ProductionQualityCheck, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ProductionQualityCheck Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Quality.Persistence.Entities.IsoStandard Stern { get; set; }
    }
}

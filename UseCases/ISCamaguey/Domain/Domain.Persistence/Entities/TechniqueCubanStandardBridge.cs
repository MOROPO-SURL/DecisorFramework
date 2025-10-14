namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, Quality.Persistence.Entities.CubanStandard, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public Technique Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Quality.Persistence.Entities.CubanStandard Stern { get ; set ; }
    }
}

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, Quality.Persistence.Entities.CubanStandard, int>
    {
        public System.Guid ProwId { get ; set ; }
        public Technique Prow { get ; set ; }
        
        public int SternId { get ; set ; }
        public Quality.Persistence.Entities.CubanStandard Stern { get ; set ; }
    }
}

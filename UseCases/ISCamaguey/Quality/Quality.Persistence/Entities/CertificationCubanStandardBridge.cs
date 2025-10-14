namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class CertificationCubanStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Certification, System.Guid, CubanStandard, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        
        public Certification Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        
        public CubanStandard Stern { get; set; }
    }
}

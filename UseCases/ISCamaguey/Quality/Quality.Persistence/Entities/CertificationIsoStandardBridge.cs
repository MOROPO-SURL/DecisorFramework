namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class CertificationIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Certification, System.Guid, IsoStandard, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        
        public Certification Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        
        public IsoStandard Stern { get; set; }
    }
}

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Technique Prow { get; set; }
        
        public System.Guid SternId { get; set; }
        public Quality.Persistence.Entities.IsoStandard Stern { get; set; }
    }
}

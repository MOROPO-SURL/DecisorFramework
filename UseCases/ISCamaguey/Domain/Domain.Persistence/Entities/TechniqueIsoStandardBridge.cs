namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class TechniqueIsoStandardBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Technique, System.Guid, Quality.Persistence.Entities.IsoStandard, int>
    {
        public System.Guid ProwId { get; set; }
        public Technique Prow { get; set; }
        
        public int SternId { get; set; }
        public Quality.Persistence.Entities.IsoStandard Stern { get; set; }
    }
}

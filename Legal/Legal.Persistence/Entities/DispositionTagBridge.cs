namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class DispositionTagBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Disposition, System.Guid, Tag, string>
    {
        public Disposition Prow { get; set; }
        public System.Guid ProwId { get; set; }

        public Tag Stern { get; set; }
        public string SternId { get; set; }
    }
}

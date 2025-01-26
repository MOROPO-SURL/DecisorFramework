namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class ClauseTagBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Clause, System.Guid, Tag, string>
    {
        public Clause Prow { get; set; }
        public System.Guid ProwId { get; set; }

        public Tag Stern { get; set; }
        public string SternId { get; set; }
    }
}

namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class ProformaClauseBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Proforma, System.Guid, Clause, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Proforma Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Clause Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
        public System.Guid SectionId { get; set; }
    }
}

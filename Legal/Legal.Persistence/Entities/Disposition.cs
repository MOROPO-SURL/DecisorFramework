namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Disposition : Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RegulationId))]
        public Regulation Regulation { get; set; }
        public System.Guid RegulationId { get; set; }

        public int Index { get; set; }

        public string Segment { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public System.Collections.Generic.List<DispositionTagBridge> TagBridges { get; set; } = new System.Collections.Generic.List<DispositionTagBridge>();
    }
}

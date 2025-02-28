namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Proforma : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public string Description { get; set; }

        public System.DateTime CreatedAt { get; set; } = System.DateTime.Now;

        public System.DateTime EditedAt { get; set;} = System.DateTime.Now;

        public System.Collections.Generic.List<ProformaClauseBridge> ClauseBridges { get; set; } = new System.Collections.Generic.List<ProformaClauseBridge> { };

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CachedDocumentId))]
        public Guama.Media.Persistence.Entities.Document CachedDocument { get; set; }
        public System.Guid? CachedDocumentId { get; set; }

        public System.DateTime? CachedDocumentAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RawDocumentId))]
        public Guama.Media.Persistence.Entities.Document RawDocument { get; set; }
        public System.Guid? RawDocumentId { get; set; }
    }
}

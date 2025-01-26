namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Proclamation : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public System.DateTime ReleasedAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public ProclamationKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; } // ISSN Ej: 1682-7511

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid? DocumentId { get; set; }
    }
}

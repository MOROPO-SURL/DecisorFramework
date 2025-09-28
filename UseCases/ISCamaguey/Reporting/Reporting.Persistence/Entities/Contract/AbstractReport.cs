namespace MOROPO.ISCamaguey.Decisor.Reporting.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractReport : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid? DocumentId { get; set; }
    }
}

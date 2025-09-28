namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class OppositionReport : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
       
        public int Priority { get ; set ; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description {  get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Framework.Decisor.Domain.Persistence.Entities.PersonContact Author { get; set; }
        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ReportId))]
        public ProjectReport Report { get; set; }
        public System.Guid ReportId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid? DocumentId { get; set; }
    }
}

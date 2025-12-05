namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractContract : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>, Core.Persistence.Entities.Contract.IYearIndexable
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Objective { get; set; }

        public System.DateTime StarAt { get; set; }

        public int? DurationUnitCount { get; set; }

        public Enumerations.DurationUnitMeasureKind? DurationUnitMeasureKind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid? DocumentId { get; set; }
    }
}


namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public sealed class AssessmentQualityCheck : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AssessmentId))]
        public Assessment Assessment { get; set; }
        public System.Guid AssessmentId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0D, 100D)]
        public double QualityPercent { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public System.Collections.Generic.List<AssessmentQualityCheckCubanStandardBridge> CubanStandardBridge { get; set; } = new System.Collections.Generic.List<AssessmentQualityCheckCubanStandardBridge>();

        public System.Collections.Generic.List<AssessmentQualityCheckIsoStandardBridge> IsoStandardBridge { get; set; } = new System.Collections.Generic.List<AssessmentQualityCheckIsoStandardBridge>();
    }
}

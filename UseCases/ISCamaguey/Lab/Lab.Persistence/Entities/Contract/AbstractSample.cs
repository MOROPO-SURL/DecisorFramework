using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract
{
    public abstract class AbstractSample : Framework.Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Observation {  get; set; }

        public System.DateTime? PickedAt { get; set; }

        public System.DateTime? HandledAt { get; set; }

        public System.DateTime? AssessmentAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid? FeatureImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleKindId))]
        public SampleKind SampleKind { get; set; }
        public System.Guid SampleKindId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Framework.Decisor.Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }
    }
}

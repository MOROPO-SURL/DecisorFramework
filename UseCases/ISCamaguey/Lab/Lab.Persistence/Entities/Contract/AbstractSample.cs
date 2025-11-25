using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract
{
    public abstract class AbstractSample : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LabelId))]
        public SampleReceptionLabel Label { get; set; }
        public System.Guid? LabelId { get; set; }

        public string Observation {  get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid FeatureImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleKindId))]
        public SampleKind SampleKind { get; set; }
        public System.Guid SampleKindId { get; set; }

        public decimal Amount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(UnitMeasurementId))]
        public Framework.Decisor.Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid UnitMeasurementId { get; set; }
    }
}

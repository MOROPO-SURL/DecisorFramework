namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractSampleDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, long> where TEntity : Persistence.Entities.Contract.AbstractSample
    {
        public long Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public SampleReceptionLabelDisplayModel Label { get; set; }

        public string Observation { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel SampleKind { get; set; }

        public decimal Amount { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            Observation = entity.Observation;
            Amount = entity.Amount;

            if (entity.Label != null)
            {
                Label = new SampleReceptionLabelDisplayModel();

                Label.Import(entity.Label);
            }

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Framework.Decisor.Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }

            if (entity.SampleKind != null)
            {
                SampleKind = new Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel();

                SampleKind.Import(entity.SampleKind);
            }

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }
        }
    }
}

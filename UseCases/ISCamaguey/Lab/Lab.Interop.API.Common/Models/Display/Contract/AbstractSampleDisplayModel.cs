namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractSampleDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractSample
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime? PickedAt { get; set; }

        public System.DateTime? HandledAt { get; set; }

        public string Observation { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel SampleKind { get; set; }

        public decimal Amount { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Index = entity.Index;
            Year = entity.Year;
            At = entity.At;
            PickedAt = entity.PickedAt;
            HandledAt = entity.HandledAt;
            Observation = entity.Observation;
            Amount = entity.Amount;

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

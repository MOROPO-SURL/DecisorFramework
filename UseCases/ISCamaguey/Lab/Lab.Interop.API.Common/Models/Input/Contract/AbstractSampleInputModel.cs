namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractSampleInputModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, long> where TEntity : Persistence.Entities.Contract.AbstractSample
    {
        public long Id { get; set; }

        public int Priority { get; set; }

        public System.Guid? LabelId { get; set; }

        public string Observation { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public System.Guid SampleKindId { get; set; }

        public decimal Amount { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Priority = Priority;
            entity.Observation = Observation;
            entity.Amount = Amount;

            if (entity.LabelId != LabelId)
            {
                entity.Label = null;
                entity.LabelId = LabelId;
            }

            if (entity.SampleKindId != SampleKindId)
            {
                entity.SampleKind = null;
                entity.SampleKindId = SampleKindId;
            }

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }
        }
    }
}

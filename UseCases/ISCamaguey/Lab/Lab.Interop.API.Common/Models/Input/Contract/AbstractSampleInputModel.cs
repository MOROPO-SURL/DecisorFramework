namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractSampleInputModel<TEntity> : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractSample
    {
        public int Index { get; set; }

        public int Year { get; set; }

        public string Observation { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public System.Guid SampleKindId { get; set; }

        public decimal Amount { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public override void Mergue(TEntity entity)
        {
            entity.Index = Index;
            entity.Year = Year;
            entity.Observation = Observation;
            entity.Amount = Amount;

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

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasingInputModel<TEntity> : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasing
    {
        public System.Guid PostulationId { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid CostCenterId { get; set; }

        public int Priority { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Objective { get; set; }

        public System.DateTime StartAt { get; set; }

        public int DurationUnitCount { get; set; }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind DurationUnitMeasureKind { get; set; }

        public double Feed { get; set; }

        public System.Guid PaymentTermId { get; set; }

        public override void Mergue(TEntity entity)
        {
            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.CostCenterId != CostCenterId)
            {
                entity.CostCenter = null;
                entity.CostCenterId = CostCenterId;
            }
        }
    }
}

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasingInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasing
    {
        public System.Guid Id { get; set; }

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

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Contacts { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
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

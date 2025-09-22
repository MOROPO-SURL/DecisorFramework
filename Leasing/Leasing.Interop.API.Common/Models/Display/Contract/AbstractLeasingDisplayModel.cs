namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeasingDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasing
    {
        public System.Guid Id { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel CostCenter { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.CostCenter != null)
            {
                CostCenter = new Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel();

                CostCenter.Import(entity.CostCenter);
            }
        }
    }
}

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractProviderBudgetProductInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractProviderBudgetProduct
    {
        public System.Guid Id { get; set; }

        public System.Guid BudgetId { get; set; }

        public System.Guid ProductId { get; set; }

        public System.Guid? ClassificationId { get; set; }

        public decimal UnitPrice { get; set; }

        public System.Guid CurrentyId { get; set; }

        public decimal Amount { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.UnitPrice = UnitPrice;
            entity.Amount = Amount;

            if (entity.ProductId != ProductId)
            {
                entity.Product = null;
                entity.ProductId = ProductId;
            }

            if (entity.ClassificationId != ClassificationId)
            {
                entity.Classification = null;
                entity.ClassificationId = ClassificationId;
            }

            if (entity.CurrentyId != CurrentyId)
            {
                entity.Currenty = null;
                entity.CurrentyId = CurrentyId;
            }

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }
        }
    }
}

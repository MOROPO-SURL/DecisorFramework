namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseRequestExpectedProductAdquisitionInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PurchaseRequestExpectedProductAdquisition, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid BudgetId { get; set; }

        public System.Guid ProductId { get; set; }

        public System.Guid? ClassificationId { get; set; }

        public decimal UnitPrice { get; set; }

        public System.Guid CurrentyId { get; set; }

        public decimal Amount { get; set; }

        public System.Guid UnitMeasurementId { get; set; }

        public Persistence.Entities.PurchaseRequestExpectedProductAdquisition Export()
        {
            var entity = new Persistence.Entities.PurchaseRequestExpectedProductAdquisition { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PurchaseRequestExpectedProductAdquisition entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(Persistence.Entities.PurchaseRequestExpectedProductAdquisition entity)
        {
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

            if (entity.UnitMeasurementId != UnitMeasurementId)
            {
                entity.UnitMeasurement = null;
                entity.UnitMeasurementId = UnitMeasurementId;
            }
        }
    }
}

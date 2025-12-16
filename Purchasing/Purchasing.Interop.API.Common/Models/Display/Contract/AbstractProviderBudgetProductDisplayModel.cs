namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractProviderBudgetProductDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractProviderBudgetProduct
    {
        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }

        public decimal UnitPrice { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get; set; }

        public decimal Amount { get; set; }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            UnitPrice = entity.UnitPrice;
            Amount = entity.Amount;

            if (entity.Product != null)
            {
                Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel();

                Product.Import(entity.Product);
            }

            if (entity.Classification != null)
            {
                Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                Classification.Import(entity.Classification);
            }

            if (entity.Currenty != null)
            {
                Currency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel();

                Currency.Import(entity.Currenty);
            }

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }
        }

        public override string ToString()
        {
            if (Classification != null) return $"{Product.Name} ({Classification.Name})";

            return Product.Name;
        }
    }
}

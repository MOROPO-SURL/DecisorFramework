namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseOrderExpectedProductResultDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseOrderExpectedProductResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get; set; }

        public decimal Amount { get; set; }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public virtual void Import(Persistence.Entities.PurchaseOrderExpectedProductResult entity)
        {
            Id = entity.Id;
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

            if (entity.UnitMeasurement != null)
            {
                UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel();

                UnitMeasurement.Import(entity.UnitMeasurement);
            }
        }

        public override string ToString()
        {
            if (Classification != null) return $"{Product.Name} ({Classification.Name}) [ {Amount:F2} {UnitMeasurement.Symbol} ]";

            return $"{Product.Name} [ {Amount:F2} {UnitMeasurement.Symbol} ]";
        }
    }
}
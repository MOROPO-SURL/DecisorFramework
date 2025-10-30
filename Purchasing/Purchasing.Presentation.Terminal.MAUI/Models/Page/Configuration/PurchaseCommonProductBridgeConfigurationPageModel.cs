namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseCommonProductBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel>
    {
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;

        public PurchaseCommonProductBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Product = model.Product;
                Amount = model.Amount;
                UnitMeasurement = model.UnitMeasurement;
            }
        }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }
    }
}

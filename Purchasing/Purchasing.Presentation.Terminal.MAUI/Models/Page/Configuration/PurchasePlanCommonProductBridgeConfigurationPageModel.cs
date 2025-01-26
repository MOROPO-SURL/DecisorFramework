using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchasePlanCommonProductBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel>
    {
        private ProductDisplayModel product;
        private decimal amount;
        private UnitMeasurementDisplayModel unitMeasurement;

        public PurchasePlanCommonProductBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel model = null) : base(model)
        {
            if (model != null)
            {
                Product = model.Product;
                Amount = model.Amount;
                UnitMeasurement = model.UnitMeasurement;
            }
        }

        public ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }
    }
}

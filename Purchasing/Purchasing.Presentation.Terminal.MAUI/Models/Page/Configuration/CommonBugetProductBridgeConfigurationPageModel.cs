namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CommonBugetProductBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.CommonBugetProductBridgeModel>
    {
        public static string ProductValidableProperty => nameof(Product);
        public static string UnitPriceValidableProperty => nameof(UnitPrice);
        public static string CurrencyValidableProperty => nameof(Currency);
        public static string AmountValidableProperty => nameof(Amount);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);

        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel classification;
        private decimal unitPrice;
        private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel currency;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;

        public CommonBugetProductBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.CommonBugetProductBridgeModel model) : base(model)
        {
            if (model == null) return;

            product = model.Product;
            classification = model.Classification;
            unitPrice = model.UnitPrice;
            currency = model.Currency;
            amount = model.Amount;
            unitMeasurement = model.UnitMeasurement;
        }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get => classification; set => SetProperty(ref classification, value); }

        public decimal UnitPrice { get => unitPrice; set => SetProperty(ref unitPrice, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get => currency; set => SetProperty(ref currency, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public System.Collections.ObjectModel.ObservableCollection<Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel> AvailableClassifications { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> AvailableUnitMeasurements { get; set; } = [];

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}

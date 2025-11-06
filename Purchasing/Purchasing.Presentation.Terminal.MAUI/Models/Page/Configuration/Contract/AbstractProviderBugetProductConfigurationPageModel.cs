namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractProviderBugetProductConfigurationPageModel<TDisplayModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TDisplayModel>
        where TDisplayModel : Interop.API.Common.Models.Display.Contract.AbstractProviderBudgetProductDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractProviderBudgetProduct
    {
        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel classification;
        private decimal unitPrice;
        private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel currency;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] availableClassifications;

        public AbstractProviderBugetProductConfigurationPageModel(TDisplayModel model) : base(model)
        {
            AvailableClassifications = [];

            if (model == null) return;

            Id = model.Id;
            product = model.Product;
            classification = model.Classification;
            unitPrice = model.UnitPrice;
            currency = model.Currency;
            amount = model.Amount;
            unitMeasurement = model.UnitMeasurement;
        }

        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get => classification; set => SetProperty(ref classification, value); }

        public decimal UnitPrice { get => unitPrice; set => SetProperty(ref unitPrice, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get => currency; set => SetProperty(ref currency, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] AvailableClassifications { get => availableClassifications; set => SetProperty(ref availableClassifications, value); }

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> AvailableUnitMeasurements { get; set; } = [];

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}

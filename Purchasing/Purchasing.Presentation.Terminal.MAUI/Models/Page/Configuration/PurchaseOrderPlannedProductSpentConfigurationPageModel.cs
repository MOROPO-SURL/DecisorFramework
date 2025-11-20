namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseOrderPlannedProductSpentConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel>
    {
        public static string ProductValidableProperty => nameof(Product);
        public static string ClassificationValidableProperty => nameof(Classification);
        public static string AmountValidableProperty => nameof(Amount);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);

        private Inventory.Interop.API.Common.Models.Display.ProductDisplayModel product;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel classification;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] availableClassifications;

        public PurchaseOrderPlannedProductSpentConfigurationPageModel(Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                product = model.Product;
                classification = model.Classification;
                amount = model.Amount;
                unitMeasurement = model.UnitMeasurement;
            }
        }

        public System.Guid Id { get; set; }

        public Inventory.Interop.API.Common.Models.Display.ProductDisplayModel Product { get => product; set => SetProperty(ref product, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel Classification { get => classification; set => SetProperty(ref classification, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel[] AvailableClassifications { get => availableClassifications; set => SetProperty(ref availableClassifications, value); }

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> AvailableUnitMeasurements { get; set; } = [];
    }
}

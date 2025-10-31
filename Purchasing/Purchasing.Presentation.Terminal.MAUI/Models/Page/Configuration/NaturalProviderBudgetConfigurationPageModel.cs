namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderBudgetConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel>
    {
        public static string NumberValidableProperty => nameof(Number);
        public static string YearValidableProperty => nameof(Year);
        public static string CommercialValidableProperty => nameof(Commercial);
        public static string ProviderValidableProperty => nameof(Provider);
        public static string ProductBridgesValidableProperty => nameof(ProductBridges);

        private int number;
        private int year;
        private string description;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel commercial;
        private Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel provider;
        private Core.Interop.API.Common.Models.Display.DocumentDisplayModel document;

        public NaturalProviderBudgetConfigurationPageModel(Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel model) : base(model)
        {
            var startYear = System.DateTime.Now.Year;
            var endYear = startYear - 3;

            for (int i = startYear; i >= endYear; i--)
            {
                AvailableYears.Add(i);
            }

            if (model == null) return;

            Id = model.Id;
            number = model.Number;
            year = model.Year;
            description = model.Description;
            commercial = model.Commercial;
            provider = model.Provider;
            ProductBridges = [.. model.ProductBridges];
            document = model.Document;
        }

        public System.Guid Id { get; set; }

        public int Number { get => number; set => SetProperty(ref number, value); }

        public int Year { get => year; set => SetProperty(ref year, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Commercial { get => commercial; set => SetProperty(ref commercial, value); }

        public Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel Provider { get => provider; set => SetProperty(ref provider, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.CommonBugetProductBridgeModel> ProductBridges { get; set; } = [];

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }

        public System.Collections.Generic.List<int> AvailableYears { get; private set; } = [];
    }
}

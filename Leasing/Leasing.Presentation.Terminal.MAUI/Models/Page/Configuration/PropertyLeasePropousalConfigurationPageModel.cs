using CommunityToolkit.Maui.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeasePropousalConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PropertyLeasePropousalDisplayModel>
    {
        public static string PropertyValidableProperty => nameof(Property);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string SpacePropousalsValidableProperty => nameof(SpacePropousals);
        public static string AuthorValidableProperty => nameof(Author);
        public static string AgreementValidableProperty => nameof(Agreement);
        public static string BaselineAmountValidableProperty => nameof(BaselineAmount);
        public static string BaselineCurrencyValidableProperty => nameof(BaselineCurrency);

        private int priority = 1;
        private string description;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Domain.Interop.API.Common.Models.Display.PropertyDisplayModel property;
        private decimal baselineAmount;
        private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel baselineCurrency;

        public PropertyLeasePropousalConfigurationPageModel(PropertyLeasePropousalDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            priority = model.Priority;
            description = model.Description;
            author = model.Author;
            agreement = model.Agreement;
            property = model.Property;
            baselineAmount = model.BaselineAmount;
            baselineCurrency = model.BaselineCurrency;
            SpacePropousals = [.. model.SpacePropousals];
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get => property; set => SetProperty(ref property, value); }

        public decimal BaselineAmount { get => baselineAmount; set => SetProperty(ref baselineAmount, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel BaselineCurrency { get => baselineCurrency; set => SetProperty(ref baselineCurrency, value); }

        public System.Collections.ObjectModel.ObservableCollection<PropertySpaceLeasePropousalDisplayModel> SpacePropousals { get; set; } = [];

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}

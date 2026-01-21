namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class VehicleLeasePropousalConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel>
{
    public static string VehicleValidableProperty => nameof(Vehicle);
    public static string DescriptionValidableProperty => nameof(Description);
    public static string AuthorValidableProperty => nameof(Author);
    public static string AgreementValidableProperty => nameof(Agreement);
    public static string BaselineAmountValidableProperty => nameof(BaselineAmount);
    public static string BaselineCurrencyValidableProperty => nameof(BaselineCurrency);

    private int priority = 1;
    private string description;
    private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;
    private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
    private Domain.Interop.API.Common.Models.Display.VehicleDisplayModel vehicle;
    private decimal baselineAmount;
    private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel baselineCurrency;

    public VehicleLeasePropousalConfigurationPageModel(Interop.API.Common.Models.Display.VehicleLeasePropousalDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        priority = model.Priority;
        description = model.Description;
        author = model.Author;
        agreement = model.Agreement;
        vehicle = model.Vehicle;
        baselineAmount = model.BaselineAmount;
        baselineCurrency = model.BaselineCurrency;
    }

    public System.Guid Id { get; set; }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

    public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

    public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get => vehicle; set => SetProperty(ref vehicle, value); }

    public decimal BaselineAmount { get => baselineAmount; set => SetProperty(ref baselineAmount, value); }

    public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel BaselineCurrency { get => baselineCurrency; set => SetProperty(ref baselineCurrency, value); }

    public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrencies { get; set; }
}

using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class BankAccountConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankAccountDisplayModel, Interop.API.Common.Models.Display.BankAccountDisplayModel, Models.Page.Configuration.BankAccountConfigurationPageModel>
{
    public BankAccountConfigurationPage(System.Action<Interop.API.Common.Models.Display.BankAccountDisplayModel> successAction, Models.Page.Configuration.BankAccountConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.BankAccountConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Branch != null)
        {
            for (int i = 0; i < model.AvailableBankBranches.Length; i++)
            {
                var current = model.AvailableBankBranches[i];

                if (model.Branch.Id != current.Id) continue;

                BankBranchPicker.SelectedIndex = i;
                BankBranchPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Currency != null)
        {
            for (int i = 0; i < model.AvailableCurrencies.Length; i++)
            {
                var current = model.AvailableCurrencies[i];

                if (model.Currency.Id != current.Id) continue;

                CurrencyPicker.SelectedIndex = i;
                CurrencyPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Cuenta Bancaria";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankAccountDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankAccountsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.BankAccountInputModel
        {
            Id = System.Guid.NewGuid(),
            IsExternal = ConcreteBindingContext.IsExternal,
            Number = ConcreteBindingContext.Number,
            Holder = ConcreteBindingContext.Holder,
            Priority = ConcreteBindingContext.Priority,
            BranchId = ConcreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex].Id,
            CurrencyId = ConcreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex].Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankAccountDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankAccountsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.BankAccountInputModel
        {
            Id = ConcreteBindingContext.Id,
            IsExternal = ConcreteBindingContext.IsExternal,
            Number = ConcreteBindingContext.Number,
            Holder = ConcreteBindingContext.Holder,
            Priority = ConcreteBindingContext.Priority,
            BranchId = ConcreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex].Id,
            CurrencyId = ConcreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex].Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
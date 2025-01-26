using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class BankAccountConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.BankAccountDisplayModel>
{
    public BankAccountConfigurationPage(System.Action<Interop.API.Common.Models.Display.BankAccountDisplayModel> successAction, Models.Page.Configuration.BankAccountConfigurationPageModel model) : base(successAction, model)
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

        var concreteBindingContext = (Models.Page.Configuration.BankAccountConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankAccountInputModel
        {
            Id = System.Guid.NewGuid(),
            IsExternal = false,
            Number = concreteBindingContext.Number,
            Priority = concreteBindingContext.Priority,
            BranchId = concreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex].Id,
            CurrencyId = concreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex].Id,
            Holder = concreteBindingContext.Holder
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankAccountDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankAccountsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.BankAccountConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankAccountInputModel
        {
            Id = concreteBindingContext.Id,
            Number = concreteBindingContext.Number,
            Priority = concreteBindingContext.Priority,
            BranchId = concreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex].Id,
            CurrencyId = concreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex].Id,
            Holder = concreteBindingContext.Holder
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class BankDebitCardConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.BankDebitCardDisplayModel>
{
    public BankDebitCardConfigurationPage(System.Action<Interop.API.Common.Models.Display.BankDebitCardDisplayModel> successAction, Models.Page.Configuration.BankDebitCardConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Tarjeta Bancaria de Débito";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankDebitCardDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankDebitCardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.BankDebitCardConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankDebitCardInputModel
        {
            Id = System.Guid.NewGuid(),
            Number = concreteBindingContext.Number,
            ExpireOn = new System.DateTime(concreteBindingContext.ExpirationYear, concreteBindingContext.ExpirationMonth, 1),
            Priority = concreteBindingContext.Priority,
            BankAccountId = concreteBindingContext.Account.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankDebitCardDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankDebitCardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.BankDebitCardConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankDebitCardInputModel
        {
            Id = concreteBindingContext.Id,
            Number = concreteBindingContext.Number,
            ExpireOn = new System.DateTime(concreteBindingContext.ExpirationYear, concreteBindingContext.ExpirationMonth, 1),
            Priority = concreteBindingContext.Priority,
            BankAccountId = concreteBindingContext.Account.Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void BankAccountPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.InternalBankAccountPickPage(BankAccountPickComplete_Callback)));
    }

    private void BankAccountPickComplete_Callback(Interop.API.Common.Models.Display.BankAccountDisplayModel model)
    {
        ((Models.Page.Configuration.BankDebitCardConfigurationPageModel)BindingContext).Account = model;

        hasChangesFlag = true;
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleLeasePropousalConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleLeasePropousalDisplayModel, VehicleLeasePropousalDisplayModel, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>
{
    public VehicleLeasePropousalConfigurationPage(System.Action<VehicleLeasePropousalDisplayModel> successAction, Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.BaselineCurrency != null)
        {
            for (int i = 0; i < model.AvailableCurrencies.Length; i++)
            {
                var current = model.AvailableCurrencies[i];

                if (model.BaselineCurrency.Id != current.Id) continue;

                BaselineCurrencyPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Propuesta de Arrendamiento de Vehículo";

    protected async override System.Threading.Tasks.Task<VehicleLeasePropousalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.VehicleLeasePropousalInputModel
        {
            Id = System.Guid.NewGuid(),
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            VehicleId = ConcreteBindingContext.Vehicle.Id,
            Priority = ConcreteBindingContext.Priority,
            BaselineAmount = ConcreteBindingContext.BaselineAmount,
            BaselineCurrencyId = ConcreteBindingContext.BaselineCurrency.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<VehicleLeasePropousalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.VehicleLeasePropousalInputModel
        {
            Id = ConcreteBindingContext.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            VehicleId = ConcreteBindingContext.Vehicle.Id,
            Priority = ConcreteBindingContext.Priority,
            BaselineAmount = ConcreteBindingContext.BaselineAmount,
            BaselineCurrencyId = ConcreteBindingContext.BaselineCurrency.Id
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

    private void VehiclePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.VehiclePickPage(VehiclePickComplete_Callback, new Domain.Interop.API.Common.Models.Filter.VehicleFilterModel { Assignments = [] })));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void VehiclePickComplete_Callback(Domain.Interop.API.Common.Models.Display.VehicleDisplayModel model)
    {
        ConcreteBindingContext.Vehicle = model;
    }

    private void AuthorPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }
}
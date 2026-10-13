using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientPropertyLeasingControlActionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<LegalClientPropertyLeasingControlActionDisplayModel, LegalClientPropertyLeasingControlActionDisplayModel, Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel>
{
    public LegalClientPropertyLeasingControlActionConfigurationPage(System.Action<LegalClientPropertyLeasingControlActionDisplayModel> successAction, Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.LegalClientPropertyLeasingControlActionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Acción de Control de Arrendamiento de Inmueble a Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<LegalClientPropertyLeasingControlActionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingControlActionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new LegalClientPropertyLeasingControlActionInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            SupervisionGroupId = ConcreteBindingContext.SupervisionGroup.Id,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<LegalClientPropertyLeasingControlActionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingControlActionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new LegalClientPropertyLeasingControlActionInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            SupervisionGroupId = ConcreteBindingContext.SupervisionGroup.Id,
            Description = ConcreteBindingContext.Description
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

    private void LeasingPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.LegalClientPropertyLeasingPickPage(LeasingPickComplete_Callback)));
    }

    private void LeasingPickComplete_Callback(LegalClientPropertyLeasingDisplayModel model)
    {
        ConcreteBindingContext.Leasing = model;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
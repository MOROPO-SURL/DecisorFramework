using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientPropertyLeasingCollectConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<NaturalClientPropertyLeasingCollectDisplayModel, NaturalClientPropertyLeasingCollectDisplayModel, Models.Page.Configuration.NaturalClientPropertyLeasingCollectConfigurationPageModel>
{
    public NaturalClientPropertyLeasingCollectConfigurationPage(System.Action<NaturalClientPropertyLeasingCollectDisplayModel> successAction, Models.Page.Configuration.NaturalClientPropertyLeasingCollectConfigurationPageModel model) : base(successAction, model, new Validators.NaturalClientPropertyLeasingCollectConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Cobro de Arrendamiento de Inmueble a Cliente Natural";

    protected override async System.Threading.Tasks.Task<NaturalClientPropertyLeasingCollectDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientPropertyLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientPropertyLeasingCollectInputModel
        {
            Id = System.Guid.NewGuid(),
            ExpectedAt = ConcreteBindingContext.ExpectedAt,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            Amount = ConcreteBindingContext.Amount,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<NaturalClientPropertyLeasingCollectDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientPropertyLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientPropertyLeasingCollectInputModel
        {
            Id = ConcreteBindingContext.Id,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            Amount = ConcreteBindingContext.Amount,
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalClientPropertyLeasingPickPage(LeasingPickComplete_Callback)));
    }

    private void LeasingPickComplete_Callback(NaturalClientPropertyLeasingDisplayModel model)
    {
        ConcreteBindingContext.Leasing = model;
    }
}
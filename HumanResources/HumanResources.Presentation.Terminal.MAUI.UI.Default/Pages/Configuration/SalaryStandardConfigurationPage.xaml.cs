using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class SalaryStandardConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Models.Page.Configuration.SalaryStandardConfigurationPageModel>
{
    public SalaryStandardConfigurationPage(System.Action<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> successAction, Models.Page.Configuration.SalaryStandardConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Escala Salarial";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.SalaryStandardConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.SalaryStandardInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            Fee = concreteBindingContext.Fee
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.SalaryStandardConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.SalaryStandardInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            Fee = concreteBindingContext.Fee
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
}
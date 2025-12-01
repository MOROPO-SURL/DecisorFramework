using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class SampleReceptionLabelConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel>
{
    public SampleReceptionLabelConfigurationPage(System.Action<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel> successAction, Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etiqueta de Recepción";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SampleReceptionLabelsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.SampleReceptionLabelInputModel
        {
            Id = System.Guid.NewGuid(),
            Reference = ConcreteBindingContext.Reference,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SampleReceptionLabelsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.SampleReceptionLabelInputModel
        {
            Id = ConcreteBindingContext.Id,
            Reference = ConcreteBindingContext.Reference,
            Priority = ConcreteBindingContext.Priority
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
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class TechniqueConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.TechniqueDisplayModel, Interop.API.Common.Models.Display.TechniqueDisplayModel, Models.Page.Configuration.TechniqueConfigurationPageModel>
{
    public TechniqueConfigurationPage(System.Action<Interop.API.Common.Models.Display.TechniqueDisplayModel> successAction, Models.Page.Configuration.TechniqueConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.TechniqueConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Técnica";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.TechniqueDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.TechniquesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.TechniqueInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            CubanStandards = ConcreteBindingContext.CubanStandards.ToList(),
            IsoStandards = ConcreteBindingContext.IsoStandards.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.TechniqueDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.TechniquesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.TechniqueInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            CubanStandards = ConcreteBindingContext.CubanStandards.ToList(),
            IsoStandards = ConcreteBindingContext.IsoStandards.ToList()
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

    private void CubanStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.CubanStandardPickPage(CubanStandardPickComplete_Callback)));
    }

    private void CubanStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.CubanStandardDetailPage(target, null));
    }

    private void CubanStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma cubana?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

                ConcreteBindingContext.CubanStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void IsoStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.IsoStandardPickPage(IsoStandardPickComplete_Callback)));
    }

    private void IsoStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.IsoStandardDetailPage(target, null));
    }

    private void IsoStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma ISO?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

                ConcreteBindingContext.IsoStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void CubanStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel model)
    {
        ConcreteBindingContext.CubanStandards.Add(model);

        hasChangesFlag = true;
    }

    private void IsoStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel model)
    {
        ConcreteBindingContext.IsoStandards.Add(model);

        hasChangesFlag = true;
    }
}
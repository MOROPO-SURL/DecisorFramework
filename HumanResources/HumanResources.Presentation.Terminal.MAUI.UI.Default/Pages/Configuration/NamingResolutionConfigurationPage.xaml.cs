using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NamingResolutionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public NamingResolutionConfigurationPage(System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> successAction, Models.Page.Configuration.NamingResolutionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.NamingResolutionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resolución de Nombramiento";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement?.Id,
            AdmitionPropousalId = ConcreteBindingContext.AdmitionPropousal.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement?.Id,
            AdmitionPropousalId = ConcreteBindingContext.AdmitionPropousal.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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

    private void IndexSetButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayPromptAsync("Número de resolución", "Especifique el valor deseado para el número de resolución. Se espera un número entero.", "Aplicar", "Cancelar", keyboard: Microsoft.Maui.Keyboard.Numeric).ContinueWith(task =>
        {
            if (string.IsNullOrEmpty(task.Result) || task.IsCanceled) return;

            Dispatcher.Dispatch(() =>
            {
                try
                {
                    ConcreteBindingContext.Index = int.Parse(task.Result);
                }
                catch
                {
                    DisplayAlert("Aviso", "El valor especificado no es válido. Se espera un número entero.", "Aceptar");
                }
            });
        });
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void AdmitionPropousalPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.AdmitionPropousalPickPage(AdmitionPropousalPickComplete_Callback)));
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void AdmitionPropousalPickComplete_Callback(Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel model)
    {
        ConcreteBindingContext.AdmitionPropousal = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }
}
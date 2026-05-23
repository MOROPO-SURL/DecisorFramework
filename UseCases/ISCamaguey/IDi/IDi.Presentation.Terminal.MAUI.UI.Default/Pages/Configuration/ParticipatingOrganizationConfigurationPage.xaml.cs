using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ParticipatingOrganizationConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel, Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel, Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel>
{
    public ParticipatingOrganizationConfigurationPage(System.Action<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel> successAction, Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel model, Validators.ParticipatingOrganizationConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Entidad Participante";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParticipatingOrganizationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ParticipatingOrganizationInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = ConcreteBindingContext.Contact.Id,
            Priority = ConcreteBindingContext.Priority,
            KnowledgeAreas = [.. ConcreteBindingContext.KnowledgeAreas]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParticipatingOrganizationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ParticipatingOrganizationInputModel
        {
            Id = ConcreteBindingContext.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            Priority = ConcreteBindingContext.Priority,
            KnowledgeAreas = [.. ConcreteBindingContext.KnowledgeAreas]
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

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationContactPickPage(ContactPickComplete_Callback)));
    }

    private void KnowledgeAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.KnowledgeAreaPickPage(KnowledgeAreaPickComplete_Callback)));
    }

    private void KnowledgeAreaDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel;

        this.NavigationPushModalPageAsync(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.KnowledgeAreaDetailPage(target, null));
    }

    private void KnowledgeAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel;

                ConcreteBindingContext.KnowledgeAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ContactPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
    }

    private void KnowledgeAreaPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel model)
    {
        ConcreteBindingContext.KnowledgeAreas.Add(model);

        hasChangesFlag = true;
    }
}
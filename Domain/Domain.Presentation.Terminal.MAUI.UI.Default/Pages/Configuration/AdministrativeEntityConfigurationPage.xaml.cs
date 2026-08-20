using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AdministrativeEntityConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel, Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel, Models.Page.Configuration.AdministrativeEntityConfigurationPageModel>
{
    private ImageInputModel imagePickedModel;

    public AdministrativeEntityConfigurationPage(System.Action<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel> successAction, Models.Page.Configuration.AdministrativeEntityConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.AdministrativeEntityConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Kind != null)
        {
            for (int i = 0; i < model.AvailableKinds.Length; i++)
            {
                var current = model.AvailableKinds[i];

                if (model.Kind.Id != current.Id) continue;

                KindPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.OrganizationalStructure != null)
        {
            for (int i = 0; i < model.AvailableOrganizationalStructures.Length; i++)
            {
                var current = model.AvailableOrganizationalStructures[i];

                if (model.OrganizationalStructure.Id != current.Id) continue;

                OrganizationalStructurePicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Parent != null)
        {
            for (int i = 0; i < model.AvailableParents.Length; i++)
            {
                var current = model.AvailableParents[i];

                if (model.Parent.Id != current.Id) continue;

                OrganizationalStructurePicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Entidad Administrativa";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AdministrativeEntityInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            About = ConcreteBindingContext.About,
            KindId = ConcreteBindingContext.Kind.Id,
            OrganizationalStructureId = ConcreteBindingContext.OrganizationalStructure.Id,
            ParentId = ConcreteBindingContext.Parent?.Id,
            Priority = ConcreteBindingContext.Priority,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalAdministrativeEntitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AdministrativeEntityInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            About = ConcreteBindingContext.About,
            KindId = ConcreteBindingContext.Kind.Id,
            ParentId = ConcreteBindingContext.Parent?.Id,
            OrganizationalStructureId = ConcreteBindingContext.OrganizationalStructure.Id,
            Priority = ConcreteBindingContext.Priority,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
        }

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

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
    }

    private void ClearParentButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.Parent = null;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
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

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ConcreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}
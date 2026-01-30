using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class StructureConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.StructureParentalDisplayModel, Interop.API.Common.Models.Display.StructureParentalDisplayModel, Models.Page.Configuration.StructureConfigurationPageModel>
{
    private ImageInputModel imagePickedModel;

    public StructureConfigurationPage(System.Action<Interop.API.Common.Models.Display.StructureParentalDisplayModel> successAction, Models.Page.Configuration.StructureConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.StructureConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Kind != null)
        {
            for (int i = 0; i < model.AvailableKinds.Length; i++)
            {
                var current = model.AvailableKinds[i];

                if (model.Kind.Id != current.Id) continue;

                KindPicker.SelectedIndex = i;
                KindPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Parent != null)
        {
            for (int i = 0; i < model.AvailableParents.Length; i++)
            {
                var current = model.AvailableParents[i];

                if (model.Parent.Id != current.Id) continue;

                ParentPicker.SelectedIndex = i;
                ParentPicker.SelectedItem = current;

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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.StructureParentalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.StructureInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            About = ConcreteBindingContext.About,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            ParentId = ConcreteBindingContext.Parent?.Id,
            OrganizationalUnities = [.. ConcreteBindingContext.OrganizationalUnities],
            Priority = ConcreteBindingContext.Priority
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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.StructureParentalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.StructureInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            About = ConcreteBindingContext.About,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            ParentId = ConcreteBindingContext.Parent?.Id,
            OrganizationalUnities = [.. ConcreteBindingContext.OrganizationalUnities],
            Priority = ConcreteBindingContext.Priority
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

    private void AddOrganizationalUnityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationalUnityPickPage(OrganizationalUnityPickComplete_Callback)));
    }

    private void OrganizationalUnityRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta unidad organizativa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.OrganizationalUnities.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel));
        });
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

    private void OrganizationalUnityPickComplete_Callback(Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel model)
    {
        ConcreteBindingContext.OrganizationalUnities.Add(model);

        hasChangesFlag = true;
    }

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ConcreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}
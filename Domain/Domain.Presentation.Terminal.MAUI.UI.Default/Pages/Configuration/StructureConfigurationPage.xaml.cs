using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class StructureConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.StructureParentalDisplayModel>
{
    private ImageInputModel imagePickedModel;

    public StructureConfigurationPage(System.Action<Interop.API.Common.Models.Display.StructureParentalDisplayModel> successAction, Models.Page.Configuration.StructureConfigurationPageModel model) : base(successAction, model)
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

        var concreteBindingContext = (Models.Page.Configuration.StructureConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.StructureInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            About = concreteBindingContext.About,
            KindId = concreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            OrganizationalUnities = concreteBindingContext.OrganizationalUnities.ToList(),
            Priority = concreteBindingContext.Priority
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

        var concreteBindingContext = (Models.Page.Configuration.StructureConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.StructureInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            About = concreteBindingContext.About,
            KindId = concreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            OrganizationalUnities = concreteBindingContext.OrganizationalUnities.ToList(),
            Priority = concreteBindingContext.Priority
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

    private void AddOrganizationalUnityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationalUnityPickPage(OrganizationalUnityPickComplete_Callback)));
    }

    private void OrganizationalUnityRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta unidad organizativa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.StructureConfigurationPageModel)BindingContext).OrganizationalUnities.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel));
        });
    }

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void OrganizationalUnityPickComplete_Callback(Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel model)
    {
        ((Models.Page.Configuration.StructureConfigurationPageModel)BindingContext).OrganizationalUnities.Add(model);

        hasChangesFlag = true;
    }

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ((Models.Page.Configuration.StructureConfigurationPageModel)BindingContext).ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}
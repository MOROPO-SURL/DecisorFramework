using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CentralStateStructureConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.CentralStateStructureDisplayModel>
{
    private ImageInputModel imagePickedModel;

    public CentralStateStructureConfigurationPage(System.Action<Interop.API.Common.Models.Display.CentralStateStructureDisplayModel> successAction, Models.Page.Configuration.CentralStateStructureConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Organismo";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CentralStateStructureDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CentralStateStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CentralStateStructureConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CentralStateStructureInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            About = concreteBindingContext.About,
            Priority = concreteBindingContext.Priority,
            BornDate = concreteBindingContext.IsSettedBornDate ? concreteBindingContext.BornDate : null
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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CentralStateStructureDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CentralStateStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CentralStateStructureConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CentralStateStructureInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            About = concreteBindingContext.About,
            Priority = concreteBindingContext.Priority,
            BornDate = concreteBindingContext.IsSettedBornDate ? concreteBindingContext.BornDate : null
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
    }

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ((Models.Page.Configuration.CentralStateStructureConfigurationPageModel)BindingContext).ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}
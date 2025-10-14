using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertySpaceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.PropertySpaceViewModel, Interop.API.Common.Models.Input.PropertySpaceInputModel, Models.Page.Configuration.PropertySpaceConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    public PropertySpaceConfigurationPage(System.Action<Interop.API.Common.Models.Input.PropertySpaceInputModel> successAction, Models.Page.Configuration.PropertySpaceConfigurationPageModel model) : base(successAction, model, new Validators.PropertySpaceConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Espacio en Inmueble";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.PropertySpaceInputModel> PerformCreationAsync()
    {
        var model = new Interop.API.Common.Models.Input.PropertySpaceInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Area = ConcreteBindingContext.Area
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
        }

        return System.Threading.Tasks.Task.FromResult(model);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.PropertySpaceInputModel> PerformEditionAsync()
    {
        var model = new Interop.API.Common.Models.Input.PropertySpaceInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Area = ConcreteBindingContext.Area
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
        }

        return System.Threading.Tasks.Task.FromResult(model);
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
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, FeatureImagePickSuccess_Callback);
    }

    private void FeatureImagePickSuccess_Callback(ImageInputModel model)
    {
        featureImagePickedModel = model;

        ConcreteBindingContext.FeatureImageSource = featureImagePickedModel.ToImageSource();

        hasChangesFlag = true;
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ServiceOrderSampleConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ServiceOrderSampleDisplayModel, ServiceOrderSampleDisplayModel, Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    public ServiceOrderSampleConfigurationPage(System.Action<ServiceOrderSampleDisplayModel> successAction, Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.SampleKind != null)
        {
            for (int i = 0; i < model.AvailableSampleKinds.Length; i++)
            {
                var current = model.AvailableSampleKinds[i];

                if (model.SampleKind.Id != current.Id) continue;

                SampleKindPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Muestra para Órden de Servicio";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<ServiceOrderSampleDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ServiceOrderSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ServiceOrderSampleInputModel
        {
            Id = System.Guid.NewGuid(),
            ServiceOrderId = ConcreteBindingContext.Order.Id,
            Index = ConcreteBindingContext.Index,
            Year = ConcreteBindingContext.Year,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.UnitMeasurement.Id,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            Observation = ConcreteBindingContext.Observation
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ServiceOrderSampleDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ServiceOrderSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ServiceOrderSampleInputModel
        {
            Id = ConcreteBindingContext.Id,
            ServiceOrderId = ConcreteBindingContext.Order.Id,
            Index = ConcreteBindingContext.Index,
            Year = ConcreteBindingContext.Year,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.UnitMeasurement.Id,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            Observation = ConcreteBindingContext.Observation
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
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
        Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, FeatureImagePickSuccess_Callback);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void OrderPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.SampleAnalysisServiceOrderPickPage(OrderSuccessPick_Callback)));
    }

    private void LabelPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        // TODO Remove this delegate!!!
    }

    private void FeatureImagePickSuccess_Callback(ImageInputModel model)
    {
        featureImagePickedModel = model;

        ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(featureImagePickedModel.ContentData));

        hasChangesFlag = true;
    }

    private void OrderSuccessPick_Callback(CommonSampleAnalysisServiceOrderDisplayModel model)
    {
        ConcreteBindingContext.Order = model;

        hasChangesFlag = true;
    }
}
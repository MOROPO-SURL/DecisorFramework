using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ResearchSampleConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ResearchSampleDisplayModel, ResearchSampleDisplayModel, Models.Page.Configuration.ResearchSampleConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    public ResearchSampleConfigurationPage(System.Action<ResearchSampleDisplayModel> successAction, Models.Page.Configuration.ResearchSampleConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ResearchSampleConfigurationPageModel> validator) : base(successAction, model, validator)
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

    protected override string EntityTypeName => "Muestra para Investigación";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<ResearchSampleDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ResearchSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ResearchSampleInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Year = ConcreteBindingContext.Year,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.UnitMeasurement.Id,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            ProjectId = ConcreteBindingContext.Project.Id,
            Observation = ConcreteBindingContext.Observation,
            ResearcherId = ConcreteBindingContext.Project.InternalResearcherProjectParticipations.FirstOrDefault(item => item.Researcher.Employee.Contact.Id == ConcreteBindingContext.ResearcherContact.Id)?.Researcher.Id ?? ConcreteBindingContext.Project.ExternalResearcherProjectParticipations.Single(item => item.Researcher.Contact.Id == ConcreteBindingContext.ResearcherContact.Id).Researcher.Id
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

    protected override async System.Threading.Tasks.Task<ResearchSampleDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ResearchSamplesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ResearchSampleInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Year = ConcreteBindingContext.Year,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.UnitMeasurement.Id,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            Observation = ConcreteBindingContext.Observation,
            ProjectId = ConcreteBindingContext.Project.Id,
            ResearcherId = ConcreteBindingContext.Project.InternalResearcherProjectParticipations.FirstOrDefault(item => item.Researcher.Employee.Contact.Id == ConcreteBindingContext.ResearcherContact.Id)?.Researcher.Id ?? ConcreteBindingContext.Project.ExternalResearcherProjectParticipations.Single(item => item.Researcher.Contact.Id == ConcreteBindingContext.ResearcherContact.Id).Researcher.Id
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

    private void ProjectPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProjectPickPage(ProjectSuccessPick_Callback)));
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

    private void ProjectSuccessPick_Callback(IDi.Interop.API.Common.Models.Display.ProjectDisplayModel model)
    {
        ConcreteBindingContext.Project = model;

        hasChangesFlag = true;
    }
}
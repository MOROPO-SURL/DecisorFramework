using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleDisplayModel, VehicleDisplayModel, Models.Page.Configuration.VehicleConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    private readonly List<ImageInputModel> incomingImages = [];
    private readonly List<ImageDisplayModel> outgoingImages = [];

    public VehicleConfigurationPage(System.Action<VehicleDisplayModel> successAction, Models.Page.Configuration.VehicleConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.VehicleConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Brand != null)
        {
            for (int i = 0; i < model.AvailableBrands.Length; i++)
            {
                var current = model.AvailableBrands[i];

                if (model.Brand.Id != current.Id) continue;

                BrandPicker.SelectedIndex = i;

                break;
            }
        }

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

        if (model.EngineKind != null)
        {
            for (int i = 0; i < model.AvailableEngineKinds.Length; i++)
            {
                var current = model.AvailableEngineKinds[i];

                if (model.EngineKind.Id != current.Id) continue;

                EngineKindPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Structure != null)
        {
            for (int i = 0; i < model.AvailableStructures.Length; i++)
            {
                var current = model.AvailableStructures[i];

                if (model.Structure.Id != current.Id) continue;

                StructurePicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Vehículo";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<VehicleDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehiclesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.VehicleInputModel
        {
            Id = System.Guid.NewGuid(),
            Priority = ConcreteBindingContext.Priority,
            BrandId = ConcreteBindingContext.AvailableBrands[BrandPicker.SelectedIndex].Id,
            Model = ConcreteBindingContext.Model,
            Year = ConcreteBindingContext.Year,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            TrafficCirculationIdentifier = ConcreteBindingContext.TrafficCirculationIdentifier,
            Plate = ConcreteBindingContext.Plate,
            EngineKindId = ConcreteBindingContext.AvailableEngineKinds[EngineKindPicker.SelectedIndex].Id,
            EngineIdentifier = ConcreteBindingContext.EngineIdentifier,
            BodyIdentifier = ConcreteBindingContext.BodyIdentifier,
            SeatCount = ConcreteBindingContext.SeatCount,
            LoadCapacity = ConcreteBindingContext.LoadCapacity,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            TechnicalAvailabilityIndex = ConcreteBindingContext.TechnicalAvailabilityIndex,
            Description = ConcreteBindingContext.Description,
            IncomingImageItems = incomingImages
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

    protected override async System.Threading.Tasks.Task<VehicleDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehiclesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.VehicleInputModel
        {
            Id = ConcreteBindingContext.Id,
            Priority = ConcreteBindingContext.Priority,
            BrandId = ConcreteBindingContext.AvailableBrands[BrandPicker.SelectedIndex].Id,
            Model = ConcreteBindingContext.Model,
            Year = ConcreteBindingContext.Year,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            TrafficCirculationIdentifier = ConcreteBindingContext.TrafficCirculationIdentifier,
            Plate = ConcreteBindingContext.Plate,
            EngineKindId = ConcreteBindingContext.AvailableEngineKinds[EngineKindPicker.SelectedIndex].Id,
            EngineIdentifier = ConcreteBindingContext.EngineIdentifier,
            BodyIdentifier = ConcreteBindingContext.BodyIdentifier,
            SeatCount = ConcreteBindingContext.SeatCount,
            LoadCapacity = ConcreteBindingContext.LoadCapacity,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            TechnicalAvailabilityIndex = ConcreteBindingContext.TechnicalAvailabilityIndex,
            Description = ConcreteBindingContext.Description,
            IncomingImageItems = incomingImages,
            OutgoingImagetItems = outgoingImages
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, FeatureImagePickSuccess_Callback);
    }

    private void ImageItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ItemImagePickSuccess_Callback);
    }

    private void ImageItemRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta imagen?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Microsoft.Maui.Controls.ImageSource;

                if (target is Microsoft.Maui.Controls.StreamImageSource)
                {
                    var incomingImageSources = ConcreteBindingContext.ItemImageSources.OfType<Microsoft.Maui.Controls.StreamImageSource>().ToList();

                    var index = incomingImageSources.IndexOf(target as Microsoft.Maui.Controls.StreamImageSource);

                    incomingImages.RemoveAt(index);
                }
                else
                {
                    var outgoingImageSources = ConcreteBindingContext.ItemImageSources.OfType<Microsoft.Maui.Controls.UriImageSource>().ToList();

                    var index = outgoingImageSources.IndexOf(target as Microsoft.Maui.Controls.UriImageSource);

                    outgoingImages.Add(ConcreteBindingContext.ItemImageModels[index]);

                    ConcreteBindingContext.ItemImageModels.RemoveAt(index);
                }

                ConcreteBindingContext.ItemImageSources.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void FeatureImagePickSuccess_Callback(ImageInputModel model)
    {
        featureImagePickedModel = model;

        ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(featureImagePickedModel.ContentData));

        hasChangesFlag = true;
    }

    private void ItemImagePickSuccess_Callback(ImageInputModel model)
    {
        incomingImages.Add(model);

        ConcreteBindingContext.ItemImageSources.Add(Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(model.ContentData)));

        hasChangesFlag = true;
    }
}
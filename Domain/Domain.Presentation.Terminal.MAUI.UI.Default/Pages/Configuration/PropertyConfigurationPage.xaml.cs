using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertyConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PropertyDisplayModel, PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    private readonly List<ImageInputModel> incomingImages = [];
    private readonly List<ImageDisplayModel> outgoingImages = [];

    public PropertyConfigurationPage(System.Action<PropertyDisplayModel> successAction, Models.Page.Configuration.PropertyConfigurationPageModel model) : base(successAction, model)
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

    protected override string EntityTypeName => "Inmueble";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<PropertyDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            Area = ConcreteBindingContext.Area,
            Description = ConcreteBindingContext.Description,
            PostalContact = new PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            },
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

    protected override async System.Threading.Tasks.Task<PropertyDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            Area = ConcreteBindingContext.Area,
            Description = ConcreteBindingContext.Description,
            PostalContact = new PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            },
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

    private void ConfiguratePostalContactButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var statesAPIConnectClient = new Core.Interop.API.Connect.Clients.StatesAPIConnectClient(httpClientHelperProvider);

                Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PostalContactConfigurationPageModel model = null;

                if (ConcreteBindingContext.PostalContact == null)
                {
                    model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PostalContactConfigurationPageModel(null)
                    {
                        AvailableStates = await statesAPIConnectClient.GetAsync()
                    };
                }
                else
                {
                    var municipalitiesAPIConnectClient = new Core.Interop.API.Connect.Clients.MunicipalitiesAPIConnectClient(httpClientHelperProvider);

                    model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PostalContactConfigurationPageModel(ConcreteBindingContext.PostalContact)
                    {
                        AvailableStates = await statesAPIConnectClient.GetAsync(),
                        AvailableMunicipalities = new System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel>(await municipalitiesAPIConnectClient.FilterAsync(new Core.Interop.API.Common.Models.Filter.MunicipalityFilterModel { StateId = ConcreteBindingContext.PostalContact.Municipality.State.Id }))
                    };
                }

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PostalContactConfigurationPage(PostalContactConfigurationSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
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

    private void PostalContactConfigurationSuccess_Callback(Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel model)
    {
        ConcreteBindingContext.PostalContact = model;
    }
}
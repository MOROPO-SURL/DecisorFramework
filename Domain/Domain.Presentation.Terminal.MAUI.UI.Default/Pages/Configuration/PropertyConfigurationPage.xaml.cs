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
    private readonly List<Interop.API.Common.Models.Input.PropertySpaceInputModel> editionSpaces = [];
    private readonly List<Interop.API.Common.Models.Input.PropertySpaceInputModel> incomingSpaces = [];
    private readonly List<PropertySpaceDisplayModel> outgoingSpaces = [];

    public PropertyConfigurationPage(System.Action<PropertyDisplayModel> successAction, Models.Page.Configuration.PropertyConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.PropertyConfigurationPageModel> validator) : base(successAction, model, validator)
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
            Description = ConcreteBindingContext.Description,
            PostalContact = new PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode ?? 0,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            },
            IncomingImageItems = incomingImages,
            IncomingSpaces = incomingSpaces
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
            Description = ConcreteBindingContext.Description,
            PostalContact = new PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode ?? 0,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            },
            IncomingImageItems = incomingImages,
            OutgoingImagetItems = outgoingImages,
            IncomingSpaces = incomingSpaces,
            EditionSpaces = editionSpaces,
            OutgoingSpaces = outgoingSpaces
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

    private void SpaceAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new PropertySpaceConfigurationPage(SpaceCreateSuccess_Callback, new Models.Page.Configuration.PropertySpaceConfigurationPageModel(null)));
    }

    private void SpaceEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.PropertySpaceViewModel;

        this.NavigationPushPageAsync(new PropertySpaceConfigurationPage(SpaceEditSuccess_Callback, new Models.Page.Configuration.PropertySpaceConfigurationPageModel(target)));
    }

    private void SpaceRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este espacio?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Models.View.PropertySpaceViewModel;

                var handled = false;

                foreach (var item in incomingSpaces)
                {
                    if (item.Id != target.Id) continue;

                    incomingSpaces.Remove(incomingSpaces.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionSpaces)
                    {
                        if (item.Id != target.Id) continue;

                        editionSpaces.Remove(editionSpaces.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingSpaces.Add(new PropertySpaceDisplayModel
                    {
                        Id = target.Id,
                        Name = target.Name,
                        Area = target.Area,
                        Description = target.Description
                    });
                }

                ConcreteBindingContext.Spaces.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void SpaceCreateSuccess_Callback(Interop.API.Common.Models.Input.PropertySpaceInputModel model)
    {
        incomingSpaces.Add(model);

        ConcreteBindingContext.Spaces.Add(new Models.View.PropertySpaceViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Area = model.Area,
            InputFeatureImage = model.FeatureImage
        });

        hasChangesFlag = true;
    }

    private void SpaceEditSuccess_Callback(Interop.API.Common.Models.Input.PropertySpaceInputModel model)
    {
        var handled = false;

        foreach (var item in incomingSpaces)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Description = model.Description;
            item.Area = model.Area;

            if (model.FeatureImage != null)
            {
                item.FeatureImage = model.FeatureImage;
            }

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionSpaces)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Description = model.Description;
                item.Area = model.Area;

                if (model.FeatureImage != null)
                {
                    item.FeatureImage = model.FeatureImage;
                }

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionSpaces.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Spaces)
        {
            index++;

            if (item.Id != model.Id) continue;

            var oldTarget = ConcreteBindingContext.Spaces[index];

            ConcreteBindingContext.Spaces[index] = new Models.View.PropertySpaceViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Area = model.Area,
                InputFeatureImage = model.FeatureImage ?? oldTarget.InputFeatureImage,
                CurrentFeatureImage = oldTarget.CurrentFeatureImage
            };

            break;
        }

        hasChangesFlag = true;
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
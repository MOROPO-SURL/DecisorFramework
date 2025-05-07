using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertyConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PropertyDisplayModel, PropertyDisplayModel, Models.Page.Configuration.PropertyConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

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

        imagePickedData = null;
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
            PostalContact = new Core.Interop.API.Common.Models.Input.PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            }
        };

        if (imagePickedData != null)
        {
            model.FeatureImage = new Core.Interop.API.Common.Models.Input.ImageInputModel
            {
                Id = System.Guid.NewGuid(),
                ContentData = imagePickedData,
                ContentType = imageContentType,
                About = $"{EntityTypeName} {model.Id}"
            };
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
            PostalContact = new Core.Interop.API.Common.Models.Input.PostalContactItemInputModel
            {
                Label = ConcreteBindingContext.PostalContact.Label,
                Address = ConcreteBindingContext.PostalContact.Address,
                MunicipalityId = ConcreteBindingContext.PostalContact.Municipality.Id,
                ZipCode = ConcreteBindingContext.PostalContact.ZipCode,
                Latitude = ConcreteBindingContext.PostalContact.Latitude,
                Longitude = ConcreteBindingContext.PostalContact.Longitude
            }
        };

        if (imagePickedData != null)
        {
            model.FeatureImage = new Core.Interop.API.Common.Models.Input.ImageInputModel
            {
                Id = ConcreteBindingContext.FeatureImageId ?? default,
                ContentData = imagePickedData,
                ContentType = imageContentType,
                About = $"{EntityTypeName} {model.Id}"
            };
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

    private async void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (!Microsoft.Maui.Media.MediaPicker.IsCaptureSupported) PresentForImagePick();

        var action = await DisplayActionSheet("Seleccionar imagen desde", "Cancelar", null, CommonActionSheetConstants.PICKIMAGE_OPTION_CAMARA, CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY);

        if (action == CommonActionSheetConstants.PICKIMAGE_OPTION_CAMARA)
        {
            var permission = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<Microsoft.Maui.ApplicationModel.Permissions.Camera>();

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                permission = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<Microsoft.Maui.ApplicationModel.Permissions.Camera>();
            }

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                Dispatcher.Dispatch(() =>
                {
                    DisplayAlert("Aviso", string.Format("El permiso para acceder a cámara del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                    ConcreteBindingContext.IsBusy = false;
                    ConcreteBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = true;
                ConcreteBindingContext.BusyProgressMessage = "Capturando imagen ...";
            });

            await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1));

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.BusyProgressMessage = "Preparando imagen ...";
            });

            await Microsoft.Maui.Media.MediaPicker.CapturePhotoAsync().ContinueWith(PickedImageContinuationTask);
        }
        else if (action == CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY)
        {
            PresentForImagePick();
        }
    }

    private void PickedImageCroppingComplete_Callback(SkiaSharp.SKBitmap result)
    {
        if (result != null)
        {
            using (var skImage = SkiaSharp.SKImage.FromBitmap(result))
            {
                using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
                {
                    imagePickedData = skData.ToArray();
                }
            }

            result.Dispose();

            ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

            hasChangesFlag = true;
        }

        this.NavigationPopModalPageAsync();

        ConcreteBindingContext.IsBusy = false;
        ConcreteBindingContext.BusyProgressMessage = string.Empty;
    }

    private async void PresentForImagePick()
    {
        if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
        {
            var permission = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<Microsoft.Maui.ApplicationModel.Permissions.Photos>();

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                permission = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<Microsoft.Maui.ApplicationModel.Permissions.Photos>();
            }

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                Dispatcher.Dispatch(() =>
                {
                    DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                    ConcreteBindingContext.IsBusy = false;
                    ConcreteBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }
        }
        else
        {
            var permission = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<Microsoft.Maui.ApplicationModel.Permissions.StorageRead>();

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                permission = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<Microsoft.Maui.ApplicationModel.Permissions.StorageRead>();
            }

            if (permission != Microsoft.Maui.ApplicationModel.PermissionStatus.Granted)
            {
                Dispatcher.Dispatch(() =>
                {
                    DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                    ConcreteBindingContext.IsBusy = false;
                    ConcreteBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }
        }

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = true;
            ConcreteBindingContext.BusyProgressMessage = "Seleccionando imagen ...";
        });

        await Microsoft.Maui.Media.MediaPicker.PickPhotoAsync().ContinueWith(PickedImageContinuationTask);
    }

    private async System.Threading.Tasks.Task PickedImageContinuationTask(System.Threading.Tasks.Task<Microsoft.Maui.Storage.FileResult> task)
    {
        if (task.Result == null)
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;
                ConcreteBindingContext.BusyProgressMessage = string.Empty;
            });

            return;
        }

        await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromMilliseconds(100));

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.BusyProgressMessage = "Preparando imagen ...";
        });

        SkiaSharp.SKBitmap croppingImageTarget = null;

        using (var imageFileStream = await task.Result.OpenReadAsync())
        {
            using (var skStream = new SkiaSharp.SKManagedStream(imageFileStream))
            {
                croppingImageTarget = SkiaSharp.SKBitmap.Decode(skStream);
            }
        }

        Dispatcher.Dispatch(() =>
        {
            imageContentType = task.Result.ContentType;

            DisplayAlert("Recortar", "Desea recortar esta imagen?", "Si", "No").ContinueWith(cropAskTask =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (cropAskTask.Result)
                    {
                        ConcreteBindingContext.BusyProgressMessage = "Recortando imagen ...";

                        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.ImageCropPage(croppingImageTarget, PickedImageCroppingComplete_Callback)));
                    }
                    else
                    {
                        using (var skImage = SkiaSharp.SKImage.FromBitmap(croppingImageTarget))
                        {
                            using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
                            {
                                imagePickedData = skData.ToArray();
                            }
                        }

                        croppingImageTarget.Dispose();

                        ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

                        hasChangesFlag = true;

                        ConcreteBindingContext.IsBusy = false;
                        ConcreteBindingContext.BusyProgressMessage = string.Empty;
                    }
                });
            });
        });
    }

    private void PostalContactConfigurationSuccess_Callback(Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel model)
    {
        ConcreteBindingContext.PostalContact = model;
    }
}
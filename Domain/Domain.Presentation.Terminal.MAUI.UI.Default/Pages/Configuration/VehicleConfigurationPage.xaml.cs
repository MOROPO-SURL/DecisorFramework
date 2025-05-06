using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleDisplayModel, Models.Page.Configuration.VehicleConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    public VehicleConfigurationPage(System.Action<VehicleDisplayModel> successAction, Models.Page.Configuration.VehicleConfigurationPageModel model) : base(successAction, model)
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

        imagePickedData = null;
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
            Description = ConcreteBindingContext.Description
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
            Description = ConcreteBindingContext.Description
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
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
}
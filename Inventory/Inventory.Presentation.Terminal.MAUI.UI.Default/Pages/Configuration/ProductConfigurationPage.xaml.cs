using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    public ProductConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProductDisplayModel> successAction, Models.Page.Configuration.ProductConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.DefaultUnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.DefaultUnitMeasurement.Id != current.Id) continue;

                DefaultUnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Category != null)
        {
            for (int i = 0; i < model.AvailableCategories.Length; i++)
            {
                var current = model.AvailableCategories[i];

                if (model.Category.Id != current.Id) continue;

                CategoryPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Producto";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedData = null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProductDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultMetricUnityId = ConcreteBindingContext.AvailableUnitMeasurements[DefaultUnitMeasurementPicker.SelectedIndex].Id,
            CategoryId = CategoryPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableCategories[CategoryPicker.SelectedIndex].Id,
            WarehousingDecreases = ConcreteBindingContext.WarehousingDecreases.ToList(),
            Classifications = ConcreteBindingContext.Classifications.Select(item => new Interop.API.Common.Models.Input.ClassificationInputModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Priority = item.Priority,
                ProductId = ConcreteBindingContext.Id
            }).ToList()
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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProductDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultMetricUnityId = ConcreteBindingContext.AvailableUnitMeasurements[DefaultUnitMeasurementPicker.SelectedIndex].Id,
            CategoryId = CategoryPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableCategories[CategoryPicker.SelectedIndex].Id,
            WarehousingDecreases = ConcreteBindingContext.WarehousingDecreases.ToList()
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

    private async void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (!Microsoft.Maui.Media.MediaPicker.IsCaptureSupported) PresentForImagePick();

        var action = await DisplayActionSheet("Seleccionar imágen desde", "Cancelar", null, CommonActionSheetConstants.PICKIMAGE_OPTION_CAMARA, CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY);

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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void AddClassificationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ClassificationConfigurationPage(ClassificationCreateSuccess_Callback, new Models.Page.Configuration.ClassificationConfigurationPageModel(ConcreteBindingContext, null)));
    }

    private void EditClassificationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ClassificationConfigurationPage(ClassificationEditSuccess_Callback, new Models.Page.Configuration.ClassificationConfigurationPageModel(ConcreteBindingContext, ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ClassificationDisplayModel)));
    }

    private void ClassificationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta clasificación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.Classifications.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ClassificationDisplayModel));
        });
    }

    private void ClassificationCreateSuccess_Callback(Interop.API.Common.Models.Display.ClassificationDisplayModel model)
    {
        ConcreteBindingContext.Classifications.Add(model);
    }

    private void ClassificationEditSuccess_Callback(Interop.API.Common.Models.Display.ClassificationDisplayModel model)
    {
        var reference = ConcreteBindingContext.Classifications.First(item => item.Id == model.Id);

        var index = ConcreteBindingContext.Classifications.IndexOf(reference);

        ConcreteBindingContext.Classifications[index] = model;

        hasChangesFlag = true;
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

        imageContentType = task.Result.ContentType;

        using (var skImage = SkiaSharp.SKImage.FromBitmap(croppingImageTarget))
        {
            using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
            {
                imagePickedData = skData.ToArray();
            }
        }

        croppingImageTarget.Dispose();

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

            hasChangesFlag = true;

            ConcreteBindingContext.IsBusy = false;
            ConcreteBindingContext.BusyProgressMessage = string.Empty;
        });
    }
}
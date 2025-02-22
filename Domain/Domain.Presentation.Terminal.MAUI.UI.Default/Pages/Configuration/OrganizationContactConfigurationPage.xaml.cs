using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OrganizationContactConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<OrganizationContactDisplayModel, Models.Page.Configuration.OrganizationContactConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    public OrganizationContactConfigurationPage(System.Action<OrganizationContactDisplayModel> successAction, Models.Page.Configuration.OrganizationContactConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.BusinessKind != null)
        {
            for (int i = 0; i < model.AvailableBusinessKinds.Length; i++)
            {
                var current = model.AvailableBusinessKinds[i];

                if (model.BusinessKind.Id != current.Id) continue;

                BusinessKindPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Contacto (Organización)";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedData = null;
    }

    protected override async System.Threading.Tasks.Task<OrganizationContactDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OrganizationContactInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            About = ConcreteBindingContext.About,
            Priority = ConcreteBindingContext.Priority,
            BornDate = ConcreteBindingContext.IsSettedBornDate ? ConcreteBindingContext.BornDate : null,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            PhoneContacts = ConcreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = ConcreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = ConcreteBindingContext.PostalContactItems.ToList(),
            WebContacts = ConcreteBindingContext.WebContactItems.ToList()
        };

        if (imagePickedData != null)
        {
            model.Image = new Core.Interop.API.Common.Models.Input.ImageInputModel
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

    protected override async System.Threading.Tasks.Task<OrganizationContactDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OrganizationContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OrganizationContactInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            About = ConcreteBindingContext.About,
            Priority = ConcreteBindingContext.Priority,
            BornDate = ConcreteBindingContext.IsSettedBornDate ? ConcreteBindingContext.BornDate : null,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            PhoneContacts = ConcreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = ConcreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = ConcreteBindingContext.PostalContactItems.ToList(),
            WebContacts = ConcreteBindingContext.WebContactItems.ToList()
        };

        if (imagePickedData != null)
        {
            model.Image = new Core.Interop.API.Common.Models.Input.ImageInputModel
            {
                Id = ConcreteBindingContext.ImageId ?? System.Guid.NewGuid(),
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

            ConcreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

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

                        ConcreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

                        hasChangesFlag = true;

                        ConcreteBindingContext.IsBusy = false;
                        ConcreteBindingContext.BusyProgressMessage = string.Empty;
                    }
                });
            });
        });
    }
}
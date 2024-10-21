using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Terminal.MAUI.UI.Pages.Configuration;

public partial class ColaboratorConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.ColaboratorDisplayModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    public ColaboratorConfigurationPage(System.Action<Interop.API.Common.Models.Display.ColaboratorDisplayModel> successAction, Models.Page.Configuration.ColaboratorConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        for (int i = 0; i < model.AvailableSexs.Length; i++)
        {
            var current = model.AvailableSexs[i];

            if (model.Sex != current) continue;

            SexPicker.SelectedIndex = i;
            SexPicker.SelectedItem = current;

            break;
        }

        for (int i = 0; i < model.AvailableCivilStatuses.Length; i++)
        {
            var current = model.AvailableCivilStatuses[i];

            if (model.CivilStatus != current) continue;

            CivilStatusPicker.SelectedIndex = i;
            CivilStatusPicker.SelectedItem = current;

            break;
        }
    }

    protected override string EntityTypeName => "Colaborador";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedData = null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ColaboratorDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ColaboratorsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ColaboratorInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.Sex,
            CivilStatus = concreteBindingContext.CivilStatus,
            Priority = concreteBindingContext.Priority,
            PhoneContacts = concreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = concreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = concreteBindingContext.PostalContactItems.ToList(),
            WebContacts = concreteBindingContext.WebContactItems.ToList(),
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber
        };

        if (imagePickedData != null)
        {
            model.Image = new Core.Interop.API.Common.Models.Input.ImageInputModel
            {
                Id = System.Guid.NewGuid(),
                ContentData = imagePickedData,
                ContentType = imageContentType,
                About = $"Colaborador {model.Id}"
            };
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ColaboratorDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ColaboratorsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ColaboratorInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.Sex,
            CivilStatus = concreteBindingContext.CivilStatus,
            Priority = concreteBindingContext.Priority,
            PhoneContacts = concreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = concreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = concreteBindingContext.PostalContactItems.ToList(),
            WebContacts = concreteBindingContext.WebContactItems.ToList(),
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber
        };

        if (imagePickedData != null)
        {
            model.Image = new Core.Interop.API.Common.Models.Input.ImageInputModel
            {
                Id = concreteBindingContext.ImageId ?? System.Guid.NewGuid(),
                ContentData = imagePickedData,
                ContentType = imageContentType,
                About = $"Colaborador {model.Id}"
            };
        }

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private async void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        if (!Microsoft.Maui.Media.MediaPicker.IsCaptureSupported) PresentForImagePick();

        var action = await DisplayActionSheet("Seleccionar imágen desde", "Cancelar", null, Core.Presentation.Terminal.MAUI.Constants.CommonActionSheetConstants.PICKIMAGE_OPTION_CAMARA, Core.Presentation.Terminal.MAUI.Constants.CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY);

        if (action == Core.Presentation.Terminal.MAUI.Constants.CommonActionSheetConstants.PICKIMAGE_OPTION_CAMARA)
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

                    concreteBindingContext.IsBusy = false;
                    concreteBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }

            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = true;
                concreteBindingContext.BusyProgressMessage = "Capturando imagen ...";
            });

            await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1));

            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.BusyProgressMessage = "Preparando imagen ...";
            });

            await Microsoft.Maui.Media.MediaPicker.CapturePhotoAsync().ContinueWith(PickedImageContinuationTask);
        }
        else if (action == Core.Presentation.Terminal.MAUI.Constants.CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY)
        {
            PresentForImagePick();
        }
    }

    private void PickedImageCroppingComplete_Callback(SkiaSharp.SKBitmap result)
    {
        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

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

            concreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

            hasChangesFlag = true;
        }

        this.NavigationPopModalPageAsync();

        concreteBindingContext.IsBusy = false;
        concreteBindingContext.BusyProgressMessage = string.Empty;
    }

    private async void PresentForImagePick()
    {
        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

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

                    concreteBindingContext.IsBusy = false;
                    concreteBindingContext.BusyProgressMessage = string.Empty;
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

                    concreteBindingContext.IsBusy = false;
                    concreteBindingContext.BusyProgressMessage = string.Empty;
                });

                return;
            }
        }

        Dispatcher.Dispatch(() =>
        {
            concreteBindingContext.IsBusy = true;
            concreteBindingContext.BusyProgressMessage = "Seleccionando imagen ...";
        });

        await Microsoft.Maui.Media.MediaPicker.PickPhotoAsync().ContinueWith(PickedImageContinuationTask);
    }

    private async System.Threading.Tasks.Task PickedImageContinuationTask(System.Threading.Tasks.Task<Microsoft.Maui.Storage.FileResult> task)
    {
        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        if (task.Result == null)
        {
            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = false;
                concreteBindingContext.BusyProgressMessage = string.Empty;
            });

            return;
        }

        await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromMilliseconds(100));

        Dispatcher.Dispatch(() =>
        {
            concreteBindingContext.BusyProgressMessage = "Preparando imagen ...";
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
                        concreteBindingContext.BusyProgressMessage = "Recortando imagen ...";

                        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Pages.ImageCropPage(croppingImageTarget, PickedImageCroppingComplete_Callback)));
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

                        concreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

                        hasChangesFlag = true;

                        concreteBindingContext.IsBusy = false;
                        concreteBindingContext.BusyProgressMessage = string.Empty;
                    }
                });
            });
        });
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class PersonConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PersonDisplayModel, Models.Page.Configuration.PersonConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    private readonly List<PhoneContactItemInputModel> editionPhoneContactItems = [];
    private readonly List<PhoneContactItemInputModel> incomingPhoneContactItems = [];
    private readonly List<PhoneContactItemDisplayModel> outgoingPhoneContactItems = [];

    private readonly List<EmailContactItemInputModel> editionEmailContactItems = [];
    private readonly List<EmailContactItemInputModel> incomingEmailContactItems = [];
    private readonly List<EmailContactItemDisplayModel> outgoingEmailContactItems = [];

    public PersonConfigurationPage(System.Action<PersonDisplayModel> successAction, Models.Page.Configuration.PersonConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        for (int i = 0; i < model.AvailableSexs.Length; i++)
        {
            var current = model.AvailableSexs[i];

            if (model.Sex != current) continue;

            SexPicker.SelectedIndex = i;

            break;
        }
    }

    protected override string EntityTypeName => "Persona";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedData = null;
    }

    protected override async System.Threading.Tasks.Task<PersonDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PersonInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            Priority = concreteBindingContext.Priority,
            IncomingPhoneContactItems = incomingPhoneContactItems,
            IncomingEmailContactItems = incomingEmailContactItems
        };

        if (imagePickedData != null)
        {
            model.Image = new ImageInputModel
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

    protected override async System.Threading.Tasks.Task<PersonDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PersonInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            Priority = concreteBindingContext.Priority,
            EditionPhoneContactItems = editionPhoneContactItems,
            IncomingPhoneContactItems = incomingPhoneContactItems,
            OutgoingPhoneContactItems = outgoingPhoneContactItems,
            EditionEmailContactItems = editionEmailContactItems,
            IncomingEmailContactItems = incomingEmailContactItems,
            OutgoingEmailContactItems = outgoingEmailContactItems
        };

        if (imagePickedData != null)
        {
            model.Image = new ImageInputModel
            {
                Id = concreteBindingContext.ImageId ?? default,
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
        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

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
        else if (action == CommonActionSheetConstants.PICKIMAGE_OPTION_GALLERY)
        {
            PresentForImagePick();
        }
    }

    private void PhoneContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PhoneContactItemConfigurationPage(PhoneContactItemCreateSuccess_Callback, new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PhoneContactItemConfigurationPageModel(null)));
    }

    private void EmailContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.EmailContactItemConfigurationPage(EmailContactItemCreateSuccess_Callback, new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.EmailContactItemConfigurationPageModel(null)));
    }

    private void PhoneContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PhoneContactItemDisplayModel;

        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PhoneContactItemConfigurationPage(PhoneContactItemEditSuccess_Callback, new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PhoneContactItemConfigurationPageModel(target)));
    }

    private void EmailContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as EmailContactItemDisplayModel;

        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.EmailContactItemConfigurationPage(EmailContactItemEditSuccess_Callback, new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.EmailContactItemConfigurationPageModel(target)));
    }

    private void PhoneContactItemRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este teléfono?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PhoneContactItemDisplayModel;

                var handled = false;

                foreach (var item in incomingPhoneContactItems)
                {
                    if (item.Id != target.Id) continue;

                    incomingPhoneContactItems.Remove(editionPhoneContactItems.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionPhoneContactItems)
                    {
                        if (item.Id != target.Id) continue;

                        editionPhoneContactItems.Remove(editionPhoneContactItems.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingPhoneContactItems.Add(target);
                }

                ConcreteBindingContext.PhoneContactItems.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void EmailContactItemRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este correo electrónico?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as EmailContactItemDisplayModel;

                var handled = false;

                foreach (var item in incomingEmailContactItems)
                {
                    if (item.Id != target.Id) continue;

                    incomingEmailContactItems.Remove(editionEmailContactItems.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionEmailContactItems)
                    {
                        if (item.Id != target.Id) continue;

                        editionEmailContactItems.Remove(editionEmailContactItems.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingEmailContactItems.Add(target);
                }

                ConcreteBindingContext.EmailContactItems.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void PhoneContactItemCreateSuccess_Callback(PhoneContactItemDisplayModel model)
    {
        incomingPhoneContactItems.Add(new PhoneContactItemInputModel
        {
            Id = model.Id,
            Label = model.Label,
            PhoneNumber = model.PhoneNumber
        });

        ConcreteBindingContext.PhoneContactItems.Add(model);

        hasChangesFlag = true;
    }

    private void EmailContactItemCreateSuccess_Callback(EmailContactItemDisplayModel model)
    {
        incomingEmailContactItems.Add(new EmailContactItemInputModel
        {
            Id = model.Id,
            Label = model.Label,
            EmailAddress = model.EmailAddress
        });

        ConcreteBindingContext.EmailContactItems.Add(model);

        hasChangesFlag = true;
    }

    private void PhoneContactItemEditSuccess_Callback(PhoneContactItemDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingPhoneContactItems)
        {
            if (item.Id != model.Id) continue;

            item.Label = model.Label;
            item.PhoneNumber = model.PhoneNumber;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionPhoneContactItems)
            {
                if (item.Id != model.Id) continue;

                item.Label = model.Label;
                item.PhoneNumber = model.PhoneNumber;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionPhoneContactItems.Add(new PhoneContactItemInputModel
            {
                Id = model.Id,
                Label = model.Label,
                PhoneNumber = model.PhoneNumber
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.PhoneContactItems)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.PhoneContactItems[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void EmailContactItemEditSuccess_Callback(EmailContactItemDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingEmailContactItems)
        {
            if (item.Id != model.Id) continue;

            item.Label = model.Label;
            item.EmailAddress = model.EmailAddress;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionEmailContactItems)
            {
                if (item.Id != model.Id) continue;

                item.Label = model.Label;
                item.EmailAddress = model.EmailAddress;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionEmailContactItems.Add(new EmailContactItemInputModel
            {
                Id = model.Id,
                Label = model.Label,
                EmailAddress = model.EmailAddress
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.EmailContactItems)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.EmailContactItems[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void PickedImageCroppingComplete_Callback(SkiaSharp.SKBitmap result)
    {
        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

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
        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

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
        var concreteBindingContext = (Models.Page.Configuration.PersonConfigurationPageModel)BindingContext;

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

                        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.ImageCropPage(croppingImageTarget, PickedImageCroppingComplete_Callback)));
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
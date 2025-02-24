using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PersonContactConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PersonContactDisplayModel, Models.Page.Configuration.PersonContactConfigurationPageModel>
{
    private byte[] imagePickedData;
    private string imageContentType;

    private readonly List<PostalContactItemInputModel> editionPostalContactItems = [];
    private readonly List<PostalContactItemInputModel> incomingPostalContactItems = [];
    private readonly List<PostalContactItemDisplayModel> outgoingPostalContactItems = [];

    public PersonContactConfigurationPage(System.Action<PersonContactDisplayModel> successAction, Models.Page.Configuration.PersonContactConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        for (int i = 0; i < model.AvailableSexs.Length; i++)
        {
            var current = model.AvailableSexs[i];

            if (model.Sex != current) continue;

            SexPicker.SelectedIndex = i;

            break;
        }

        for (int i = 0; i < model.AvailableCivilStatuses.Length; i++)
        {
            var current = model.AvailableCivilStatuses[i];

            if (model.CivilStatus != current) continue;

            CivilStatusPicker.SelectedIndex = i;

            break;
        }
    }

    protected override string EntityTypeName => "Contacto (Persona)";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedData = null;
    }

    protected override async System.Threading.Tasks.Task<PersonContactDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PersonContactInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            CivilStatus = concreteBindingContext.AvailableCivilStatuses[CivilStatusPicker.SelectedIndex],
            Priority = concreteBindingContext.Priority,
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber,
            IncomingPostalContactItems = incomingPostalContactItems
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

    protected override async System.Threading.Tasks.Task<PersonContactDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PersonContactInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            CivilStatus = concreteBindingContext.AvailableCivilStatuses[CivilStatusPicker.SelectedIndex],
            Priority = concreteBindingContext.Priority,
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber,
            EditionPostalContactItems = editionPostalContactItems,
            IncomingPostalContactItems = incomingPostalContactItems,
            OutgoingPostalContactItems = outgoingPostalContactItems
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
        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

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

    private void PostalContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var statesAPIConnectClient = new Core.Interop.API.Connect.Clients.StatesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PostalContactConfigurationPageModel(null)
                {
                    AvailableStates = await statesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PostalContactConfigurationPage(PostalContactItemCreateSuccess_Callback, model));
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

    private void PostalContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var statesAPIConnectClient = new Core.Interop.API.Connect.Clients.StatesAPIConnectClient(httpClientHelperProvider);
                var municipalitiesAPIConnectClient = new Core.Interop.API.Connect.Clients.MunicipalitiesAPIConnectClient(httpClientHelperProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PostalContactItemDisplayModel;

                var model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PostalContactConfigurationPageModel(target)
                {
                    AvailableStates = await statesAPIConnectClient.GetAsync(),
                    AvailableMunicipalities = new System.Collections.ObjectModel.ObservableCollection<MunicipalityDisplayModel>(await municipalitiesAPIConnectClient.FilterAsync(new Core.Interop.API.Common.Models.Filter.MunicipalityFilterModel { StateId = target.Municipality.State.Id }))
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PostalContactConfigurationPage(PostalContactItemEditSuccess_Callback, model));
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

    private void PostalContactItemRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta dirección postal?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PostalContactItemDisplayModel;

                var handled = false;

                foreach (var item in incomingPostalContactItems)
                {
                    if (item.Id != target.Id) continue;

                    incomingPostalContactItems.Remove(editionPostalContactItems.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionPostalContactItems)
                    {
                        if (item.Id != target.Id) continue;

                        editionPostalContactItems.Remove(editionPostalContactItems.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingPostalContactItems.Add(target);
                }

                ConcreteBindingContext.PostalContactItems.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void PostalContactItemCreateSuccess_Callback(PostalContactItemDisplayModel model)
    {
        incomingPostalContactItems.Add(new PostalContactItemInputModel
        {
            Id = model.Id,
            Label = model.Label,
            Address = model.Address,
            ZipCode = model.ZipCode,
            MunicipalityId = model.Municipality.Id,
            Latitude = model.Latitude,
            Longitude = model.Longitude
        });

        ConcreteBindingContext.PostalContactItems.Add(model);

        hasChangesFlag = true;
    }

    private void PostalContactItemEditSuccess_Callback(PostalContactItemDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingPostalContactItems)
        {
            if (item.Id != model.Id) continue;

            item.Label = model.Label;
            item.Address = model.Address;
            item.ZipCode = model.ZipCode;
            item.MunicipalityId = model.Municipality.Id;
            item.Latitude = model.Latitude;
            item.Longitude = model.Longitude;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionPostalContactItems)
            {
                if (item.Id != model.Id) continue;

                item.Label = model.Label;
                item.Address = model.Address;
                item.ZipCode = model.ZipCode;
                item.MunicipalityId = model.Municipality.Id;
                item.Latitude = model.Latitude;
                item.Longitude = model.Longitude;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionPostalContactItems.Add(new PostalContactItemInputModel
            {
                Id = model.Id,
                Label = model.Label,
                Address = model.Address,
                ZipCode = model.ZipCode,
                MunicipalityId = model.Municipality.Id,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.PostalContactItems)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.PostalContactItems[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void PickedImageCroppingComplete_Callback(SkiaSharp.SKBitmap result)
    {
        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

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
        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

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
        var concreteBindingContext = (Models.Page.Configuration.PersonContactConfigurationPageModel)BindingContext;

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
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PersonContactConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PersonContactDisplayModel, PersonContactDisplayModel, Models.Page.Configuration.PersonContactConfigurationPageModel>
{
    private ImageInputModel imagePickedModel;

    private readonly List<PostalContactItemInputModel> editionPostalContactItems = [];
    private readonly List<PostalContactItemInputModel> incomingPostalContactItems = [];
    private readonly List<PostalContactItemDisplayModel> outgoingPostalContactItems = [];

    private readonly List<PhoneContactItemInputModel> editionPhoneContactItems = [];
    private readonly List<PhoneContactItemInputModel> incomingPhoneContactItems = [];
    private readonly List<PhoneContactItemDisplayModel> outgoingPhoneContactItems = [];

    private readonly List<EmailContactItemInputModel> editionEmailContactItems = [];
    private readonly List<EmailContactItemInputModel> incomingEmailContactItems = [];
    private readonly List<EmailContactItemDisplayModel> outgoingEmailContactItems = [];

    private readonly List<WebContactItemInputModel> editionWebContactItems = [];
    private readonly List<WebContactItemInputModel> incomingWebContactItems = [];
    private readonly List<WebContactItemDisplayModel> outgoingWebContactItems = [];

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

        if (model.User != null)
        {
            for (int i = 0; i < model.AvailableUsers.Length; i++)
            {
                var current = model.AvailableUsers[i];

                if (model.User.Id != current.Id) continue;

                UsersPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Contacto (Persona)";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<PersonContactDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PersonContactInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            LastName = ConcreteBindingContext.LastName,
            Alias = ConcreteBindingContext.Alias,
            About = ConcreteBindingContext.About,
            Sex = ConcreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            CivilStatus = ConcreteBindingContext.AvailableCivilStatuses[CivilStatusPicker.SelectedIndex],
            UserId = UsersPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableUsers[UsersPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            PersonalIdentificationNumber = ConcreteBindingContext.PersonalIdentificationNumber,
            IncomingPostalContactItems = incomingPostalContactItems,
            IncomingPhoneContactItems = incomingPhoneContactItems,
            IncomingEmailContactItems = incomingEmailContactItems,
            IncomingWebContactItems = incomingWebContactItems
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<PersonContactDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PersonContactsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PersonContactInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            LastName = ConcreteBindingContext.LastName,
            Alias = ConcreteBindingContext.Alias,
            About = ConcreteBindingContext.About,
            Sex = ConcreteBindingContext.AvailableSexs[SexPicker.SelectedIndex],
            CivilStatus = ConcreteBindingContext.AvailableCivilStatuses[CivilStatusPicker.SelectedIndex],
            UserId = UsersPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableUsers[UsersPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            PersonalIdentificationNumber = ConcreteBindingContext.PersonalIdentificationNumber,
            EditionPostalContactItems = editionPostalContactItems,
            IncomingPostalContactItems = incomingPostalContactItems,
            OutgoingPostalContactItems = outgoingPostalContactItems,
            EditionPhoneContactItems = editionPhoneContactItems,
            IncomingPhoneContactItems = incomingPhoneContactItems,
            OutgoingPhoneContactItems = outgoingPhoneContactItems,
            EditionEmailContactItems = editionEmailContactItems,
            IncomingEmailContactItems = incomingEmailContactItems,
            OutgoingEmailContactItems = outgoingEmailContactItems,
            EditionWebContactItems = editionWebContactItems,
            IncomingWebContactItems = incomingWebContactItems,
            OutgoingWebContactItems = outgoingWebContactItems
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
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
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
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

    private void PhoneContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PhoneContactItemConfigurationPage(PhoneContactItemCreateSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PhoneContactItemConfigurationPageModel(null)));
    }

    private void EmailContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.EmailContactItemConfigurationPage(EmailContactItemCreateSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.EmailContactItemConfigurationPageModel(null)));
    }

    private void WebContactItemAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.WebContactItemConfigurationPage(WebContactItemCreateSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.WebContactItemConfigurationPageModel(null)));
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

    private void PhoneContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PhoneContactItemDisplayModel;

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.PhoneContactItemConfigurationPage(PhoneContactItemEditSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.PhoneContactItemConfigurationPageModel(target)));
    }

    private void EmailContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as EmailContactItemDisplayModel;

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.EmailContactItemConfigurationPage(EmailContactItemEditSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.EmailContactItemConfigurationPageModel(target)));
    }

    private void WebContactItemEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as WebContactItemDisplayModel;

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.WebContactItemConfigurationPage(WebContactItemEditSuccess_Callback, new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.WebContactItemConfigurationPageModel(target)));
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

    private void WebContactItemRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este sitio de internet?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as WebContactItemDisplayModel;

                var handled = false;

                foreach (var item in incomingWebContactItems)
                {
                    if (item.Id != target.Id) continue;

                    incomingWebContactItems.Remove(editionWebContactItems.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionWebContactItems)
                    {
                        if (item.Id != target.Id) continue;

                        editionWebContactItems.Remove(editionWebContactItems.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingWebContactItems.Add(target);
                }

                ConcreteBindingContext.WebContactItems.Remove(target);

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

    private void WebContactItemCreateSuccess_Callback(WebContactItemDisplayModel model)
    {
        incomingWebContactItems.Add(new WebContactItemInputModel
        {
            Id = model.Id,
            Label = model.Label,
            Url = model.Url
        });

        ConcreteBindingContext.WebContactItems.Add(model);

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

    private void WebContactItemEditSuccess_Callback(WebContactItemDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingWebContactItems)
        {
            if (item.Id != model.Id) continue;

            item.Label = model.Label;
            item.Url = model.Url;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionWebContactItems)
            {
                if (item.Id != model.Id) continue;

                item.Label = model.Label;
                item.Url = model.Url;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionWebContactItems.Add(new WebContactItemInputModel
            {
                Id = model.Id,
                Label = model.Label,
                Url = model.Url
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.WebContactItems)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.WebContactItems[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ConcreteBindingContext.ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}
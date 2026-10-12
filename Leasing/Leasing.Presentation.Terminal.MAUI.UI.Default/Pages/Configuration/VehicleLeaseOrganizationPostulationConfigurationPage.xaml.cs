using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleLeaseOrganizationPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleLeaseOrganizationPostulationDisplayModel, VehicleLeaseOrganizationPostulationDisplayModel, Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel>
{
    private readonly List<DocumentInputModel> editionDocuments = [];
    private readonly List<DocumentInputModel> incomingDocuments = [];
    private readonly List<DocumentDisplayModel> outgoingDocuments = [];

    public VehicleLeaseOrganizationPostulationConfigurationPage(System.Action<VehicleLeaseOrganizationPostulationDisplayModel> successAction, Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel model) : base(successAction, model, new Validators.VehicleLeaseOrganizationPostulationConfigurationValidator())
    {
        InitializeComponent();

        if (model.MainPostalContactItem != null)
        {
            for (int i = 0; i < model.Contact.Identity.PostalContacts.Length; i++)
            {
                var current = model.Contact.Identity.PostalContacts[i];

                if (model.MainPostalContactItem.Id != current.Id) continue;

                PostalContactItemPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Postulante Jurídico";

    protected override async System.Threading.Tasks.Task<VehicleLeaseOrganizationPostulationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeaseOrganizationPostulationInputModel
        {
            Id = System.Guid.NewGuid(),
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            MainPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[PostalContactItemPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument,
            BankAccountId = ConcreteBindingContext.BankAccount.Id,
            IncomingDocuments = incomingDocuments,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<VehicleLeaseOrganizationPostulationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeaseOrganizationPostulationInputModel
        {
            Id = ConcreteBindingContext.Id,
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            MainPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[PostalContactItemPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument,
            BankAccountId = ConcreteBindingContext.BankAccount.Id,
            IncomingDocuments = incomingDocuments,
            EditionDocuments = editionDocuments,
            OutgoingDocuments = outgoingDocuments,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.EditAsync(model);

        return null;
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationContactPickPage(ContactPickComplete_Callback)));
    }

    private void DocumentAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new Dictionary<Microsoft.Maui.Devices.DevicePlatform, IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, [ "public.my.comic.extension" ] }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, [ "application/comics" ] }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".png", ".jpg", ".jpeg", ".bmp"] }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, [ "cbr", "cbz" ] }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            var filePickResult = task.Result;

            using var stream = await filePickResult.OpenReadAsync();

            var name = System.IO.Path.GetFileNameWithoutExtension(filePickResult.FileName);
            var data = new byte[stream.Length];

            stream.Read(data, 0, (int)stream.Length);

            Dispatcher.Dispatch(() =>
            {
                var model = new DocumentInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Name = name,
                    ContentData = data,
                    ContentType = filePickResult.ContentType
                };

                incomingDocuments.Add(model);

                ConcreteBindingContext.Documents.Add(new DocumentDisplayModel
                {
                    Name = name,
                    Extension = System.IO.Path.GetExtension(filePickResult.FileName),
                    Length = data.Length
                });
            });
        });
    }

    private void DocumentEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DocumentDisplayModel;

        var model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.DocumentConfigurationPageModel(target);

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.DocumentConfigurationPage(DocumentEditSuccess_Callback, model));
    }

    private void DocumentRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este documento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DocumentDisplayModel;

                var handled = false;

                foreach (var item in incomingDocuments)
                {
                    if (item.Id != target.Id) continue;

                    incomingDocuments.Remove(incomingDocuments.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionDocuments)
                    {
                        if (item.Id != target.Id) continue;

                        editionDocuments.Remove(editionDocuments.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingDocuments.Add(target);
                }

                ConcreteBindingContext.Documents.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
        ConcreteBindingContext.TaxIdentificationNumber = model.TaxIdentificationNumber;
        ConcreteBindingContext.StateIdentificationCode = model.StateIdentificationCode;

        if (model.MainPostalContactItem != null)
        {
            for (int i = 0; i < ConcreteBindingContext.Contact.Identity.PostalContacts.Length; i++)
            {
                var current = ConcreteBindingContext.Contact.Identity.PostalContacts[i];

                if (model.MainPostalContactItem.Id != current.Id) continue;

                PostalContactItemPicker.SelectedIndex = i;

                break;
            }
        }
    }

    private void BankAccountPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.LegalClientByContactBankAccountPickPage(BankAccountPickComplete_Callback, ConcreteBindingContext.Contact)));
    }

    private void BankAccountPickComplete_Callback(Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel model)
    {
        ConcreteBindingContext.BankAccount = model;

        hasChangesFlag = true;
    }

    private void DocumentEditSuccess_Callback(DocumentDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingDocuments)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionDocuments)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionDocuments.Add(new DocumentInputModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Documents)
        {
            index++;

            if (item.Id != model.Id) continue;

            model.Extension = item.Extension;
            model.Length = item.Length;

            ConcreteBindingContext.Documents[index] = model;

            break;
        }

        hasChangesFlag = true;
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VacantPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VacantPostulationDisplayModel, VacantPostulationDisplayModel, Models.Page.Configuration.VacantPostulationConfigurationPageModel>
{
    private readonly List<DocumentInputModel> editionDocuments = [];
    private readonly List<DocumentInputModel> incomingDocuments = [];
    private readonly List<DocumentDisplayModel> outgoingDocuments = [];
    private readonly List<VacantPostulationOcupationInputModel> editionOcupations = [];
    private readonly List<VacantPostulationOcupationInputModel> incomingOcupations = [];
    private readonly List<VacantPostulationOcupationDisplayModel> outgoingOcupations = [];

    public VacantPostulationConfigurationPage(System.Action<VacantPostulationDisplayModel> successAction, Models.Page.Configuration.VacantPostulationConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();

        if (model.Schooling != null)
        {
            for (int i = 0; i < model.AvailableSchoolings.Length; i++)
            {
                var current = model.AvailableSchoolings[i];

                if (model.Schooling.Id != current.Id) continue;

                SchoolingPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.OfficialPostalContactItem != null) 
        {
            for (int i = 0; i < model.Contact.Identity.PostalContacts.Length; i++)
            {
                var current = model.Contact.Identity.PostalContacts[i];

                if (model.OfficialPostalContactItem.Id != current.Id) continue;

                MainPostalContactItemPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.AlternativePostalContactItem != null)
        {
            for (int i = 0; i < model.Contact.Identity.PostalContacts.Length; i++)
            {
                var current = model.Contact.Identity.PostalContacts[i];

                if (model.AlternativePostalContactItem.Id != current.Id) continue;

                AltPostalContactItemPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Postulación a Vacante";

    protected override async System.Threading.Tasks.Task<VacantPostulationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VacantPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new VacantPostulationInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            StaffId = ConcreteBindingContext.Staff.Id,
            VacantId = ConcreteBindingContext.Vacant.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            OfficialPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[MainPostalContactItemPicker.SelectedIndex].Id,
            AlternativePostalContactItemId = AltPostalContactItemPicker.SelectedIndex >= 0 ? ConcreteBindingContext.Contact.Identity.PostalContacts[AltPostalContactItemPicker.SelectedIndex].Id : null,
            SchoolingId = ConcreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            SchoolingComplement = ConcreteBindingContext.SchoolingComplement,
            MaleParentName = ConcreteBindingContext.MaleParentName,
            FemaleParentName = ConcreteBindingContext.FemaleParentName,
            Alignment = ConcreteBindingContext.Alignment,
            ResponsabilityCommitment = ConcreteBindingContext.ResponsabilityCommitment,
            PersonalIdentificationNumber = !string.IsNullOrEmpty(ConcreteBindingContext.PersonalIdentificationNumber) && !string.IsNullOrWhiteSpace(ConcreteBindingContext.ResponsabilityCommitment) && ConcreteBindingContext.PersonalIdentificationNumber != ConcreteBindingContext.Contact.PersonalIdentificationNumber ? ConcreteBindingContext.PersonalIdentificationNumber : null,
            IncomingDocuments = incomingDocuments,
            IncomingOcupations = incomingOcupations
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<VacantPostulationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VacantPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new VacantPostulationInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            StaffId = ConcreteBindingContext.Staff.Id,
            VacantId = ConcreteBindingContext.Vacant.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            OfficialPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[MainPostalContactItemPicker.SelectedIndex].Id,
            AlternativePostalContactItemId = AltPostalContactItemPicker.SelectedIndex >= 0 ? ConcreteBindingContext.Contact.Identity.PostalContacts[AltPostalContactItemPicker.SelectedIndex].Id : null,
            SchoolingId = ConcreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            SchoolingComplement = ConcreteBindingContext.SchoolingComplement,
            MaleParentName = ConcreteBindingContext.MaleParentName,
            FemaleParentName = ConcreteBindingContext.FemaleParentName,
            Alignment = ConcreteBindingContext.Alignment,
            ResponsabilityCommitment = ConcreteBindingContext.ResponsabilityCommitment,
            PersonalIdentificationNumber = !string.IsNullOrEmpty(ConcreteBindingContext.PersonalIdentificationNumber) && !string.IsNullOrWhiteSpace(ConcreteBindingContext.ResponsabilityCommitment) && ConcreteBindingContext.PersonalIdentificationNumber != ConcreteBindingContext.Contact.PersonalIdentificationNumber ? ConcreteBindingContext.PersonalIdentificationNumber : null,
            IncomingDocuments = incomingDocuments,
            EditionDocuments = editionDocuments,
            OutgoingDocuments = outgoingDocuments,
            IncomingOcupations = incomingOcupations,
            EditionOcupations = editionOcupations,
            OutgoingOcupations = outgoingOcupations
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void VacantPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.VacantPickPage([Persistence.Enumerations.VacantOcupationMode.Admision], VacantPickComplete_Callback)));
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
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

    private void OcupationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var apiConnectClient = new Legal.Interop.API.Connect.Clients.CentralStateStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.VacantPostulationOcupationConfigurationPageModel(null)
                {
                    AvailableCentralStateStructures = await apiConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new VacantPostulationOcupationConfigurationPage(OcupationCreateSuccess_Callback, model));
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

    private void OcupationEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var apiConnectClient = new Legal.Interop.API.Connect.Clients.CentralStateStructuresAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.VacantPostulationOcupationConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel)
                {
                    AvailableCentralStateStructures = await apiConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new VacantPostulationOcupationConfigurationPage(OcupationEditSuccess_Callback, model));
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

    private void OcupationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta cupación anterior?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel;

                var handled = false;

                foreach (var item in incomingOcupations)
                {
                    if (item.Id != target.Id) continue;

                    incomingOcupations.Remove(editionOcupations.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionOcupations)
                    {
                        if (item.Id != target.Id) continue;

                        editionOcupations.Remove(editionOcupations.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingOcupations.Add(target);
                }

                ConcreteBindingContext.Ocupations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void OcupationCreateSuccess_Callback(VacantPostulationOcupationDisplayModel model)
    {
        incomingOcupations.Add(new VacantPostulationOcupationInputModel
        {
            Id = model.Id,
            OrganizationName = model.OrganizationName,
            OrganizationAddress = model.OrganizationAddress,
            CentralStateStructureId = model.CentralStateStructure.Id,
            RepresentativeName = model.RepresentativeName,
            StartAt = model.StartAt,
            EndAt = model.EndAt
        });

        ConcreteBindingContext.Ocupations.Add(model);

        hasChangesFlag = true;
    }

    private void OcupationEditSuccess_Callback(VacantPostulationOcupationDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingOcupations)
        {
            if (item.Id != model.Id) continue;

            item.OrganizationName = model.OrganizationName;
            item.OrganizationAddress = model.OrganizationAddress;
            item.CentralStateStructureId = model.CentralStateStructure.Id;
            item.RepresentativeName = model.RepresentativeName;
            item.StartAt = model.StartAt;
            item.EndAt = model.EndAt;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionOcupations)
            {
                if (item.Id != model.Id) continue;

                item.OrganizationName = model.OrganizationName;
                item.OrganizationAddress = model.OrganizationAddress;
                item.CentralStateStructureId = model.CentralStateStructure.Id;
                item.RepresentativeName = model.RepresentativeName;
                item.StartAt = model.StartAt;
                item.EndAt = model.EndAt;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionOcupations.Add(new VacantPostulationOcupationInputModel
            {
                Id = model.Id,
                OrganizationName = model.OrganizationName,
                OrganizationAddress = model.OrganizationAddress,
                CentralStateStructureId = model.CentralStateStructure.Id,
                RepresentativeName = model.RepresentativeName,
                StartAt = model.StartAt,
                EndAt = model.EndAt
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Ocupations)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Ocupations[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void VacantPickComplete_Callback(Models.View.StaffVacantViewModel model)
    {
        ConcreteBindingContext.Staff = model.Staff;
        ConcreteBindingContext.Vacant = model.Vacant;
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
        ConcreteBindingContext.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
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
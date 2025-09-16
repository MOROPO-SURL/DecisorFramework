using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OcupationCandidateConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<OcupationCandidateDisplayModel, OcupationCandidateDisplayModel, Models.Page.Configuration.OcupationCandidateConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult rawMedicalCheckDocumentFilePickResult;
    private Microsoft.Maui.Storage.FileResult rawPhysicologicalCheckDocumentFilePickResult;
    private Microsoft.Maui.Storage.FileResult rawDefenseStatusCheckDocumentFilePickResult;
    private Microsoft.Maui.Storage.FileResult rawResearchResultDocumentFilePickResult;
    private Microsoft.Maui.Storage.FileResult rawModelDocumentFilePickResult;

    public OcupationCandidateConfigurationPage(System.Action<OcupationCandidateDisplayModel> successAction, Models.Page.Configuration.OcupationCandidateConfigurationPageModel model) : base(successAction, model, null)    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Candidato a Admisión";

    protected override async System.Threading.Tasks.Task<OcupationCandidateDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OcupationCandidatesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new OcupationCandidateInputModel
        {
            Id = System.Guid.NewGuid(),
            InterviewAt = ConcreteBindingContext.InterviewAt,
            PostulationId = ConcreteBindingContext.Postulation.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Description = ConcreteBindingContext.Description,
            MedicalCheckAt = ConcreteBindingContext.MedicalCheckAt,
            PhysicologicalCheckAt = ConcreteBindingContext.PhysicologicalCheckAt,
            DefenseStatusCheckAt = ConcreteBindingContext.DefenseStatusCheckAt,
            ResearchRequestAt = ConcreteBindingContext.ResearchRequestAt,
            ResearchResultAt = ConcreteBindingContext.ResearchResultAt
        };

        if (rawMedicalCheckDocumentFilePickResult != null)
        {
            using var stream = await rawMedicalCheckDocumentFilePickResult.OpenReadAsync();

            model.RawMedicalCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawMedicalCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawMedicalCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawMedicalCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawPhysicologicalCheckDocumentFilePickResult != null)
        {
            using var stream = await rawPhysicologicalCheckDocumentFilePickResult.OpenReadAsync();

            model.RawPhysicologicalCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawPhysicologicalCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawPhysicologicalCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawPhysicologicalCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawDefenseStatusCheckDocumentFilePickResult != null)
        {
            using var stream = await rawDefenseStatusCheckDocumentFilePickResult.OpenReadAsync();

            model.RawDefenseStatusCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawDefenseStatusCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawDefenseStatusCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawDefenseStatusCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawResearchResultDocumentFilePickResult != null)
        {
            using var stream = await rawResearchResultDocumentFilePickResult.OpenReadAsync();

            model.RawResearchResultDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawResearchResultDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawResearchResultDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawResearchResultDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawModelDocumentFilePickResult != null)
        {
            using var stream = await rawModelDocumentFilePickResult.OpenReadAsync();

            model.RawModelDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawModelDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawModelDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawModelDocument.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<OcupationCandidateDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OcupationCandidatesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new OcupationCandidateInputModel
        {
            Id = ConcreteBindingContext.Id,
            InterviewAt = ConcreteBindingContext.InterviewAt,
            PostulationId = ConcreteBindingContext.Postulation.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Description = ConcreteBindingContext.Description,
            MedicalCheckAt = ConcreteBindingContext.MedicalCheckAt,
            PhysicologicalCheckAt = ConcreteBindingContext.PhysicologicalCheckAt,
            DefenseStatusCheckAt = ConcreteBindingContext.DefenseStatusCheckAt,
            ResearchRequestAt = ConcreteBindingContext.ResearchRequestAt,
            ResearchResultAt = ConcreteBindingContext.ResearchResultAt
        };

        if (rawMedicalCheckDocumentFilePickResult != null)
        {
            using var stream = await rawMedicalCheckDocumentFilePickResult.OpenReadAsync();

            model.RawMedicalCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawMedicalCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawMedicalCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawMedicalCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawPhysicologicalCheckDocumentFilePickResult != null)
        {
            using var stream = await rawPhysicologicalCheckDocumentFilePickResult.OpenReadAsync();

            model.RawPhysicologicalCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawPhysicologicalCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawPhysicologicalCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawPhysicologicalCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawDefenseStatusCheckDocumentFilePickResult != null)
        {
            using var stream = await rawDefenseStatusCheckDocumentFilePickResult.OpenReadAsync();

            model.RawDefenseStatusCheckDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawDefenseStatusCheckDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawDefenseStatusCheckDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawDefenseStatusCheckDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawResearchResultDocumentFilePickResult != null)
        {
            using var stream = await rawResearchResultDocumentFilePickResult.OpenReadAsync();

            model.RawResearchResultDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawResearchResultDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawResearchResultDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawResearchResultDocument.ContentData, 0, (int)stream.Length);
        }

        if (rawModelDocumentFilePickResult != null)
        {
            using var stream = await rawModelDocumentFilePickResult.OpenReadAsync();

            model.RawModelDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawModelDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawModelDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawModelDocument.ContentData, 0, (int)stream.Length);
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

    private void RawMedicalCheckDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            rawMedicalCheckDocumentFilePickResult = task.Result;

            using var stream = await rawMedicalCheckDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawMedicalCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawMedicalCheckDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawMedicalCheckDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void RawPhysicologicalCheckDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            rawPhysicologicalCheckDocumentFilePickResult = task.Result;

            using var stream = await rawPhysicologicalCheckDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawPhysicologicalCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawPhysicologicalCheckDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawPhysicologicalCheckDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void RawDefenseStatusCheckDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            rawDefenseStatusCheckDocumentFilePickResult = task.Result;

            using var stream = await rawDefenseStatusCheckDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawDefenseStatusCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawDefenseStatusCheckDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawDefenseStatusCheckDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void RawResearchResultDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            rawResearchResultDocumentFilePickResult = task.Result;

            using var stream = await rawResearchResultDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawResearchResultDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawResearchResultDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawResearchResultDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void RawModelDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            rawModelDocumentFilePickResult = task.Result;

            using var stream = await rawModelDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawModelDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawModelDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawModelDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void PostulationPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.VacantPostulationPickPage(PostulationPickComplete_Callback)));
    }

    private void ResponsiblePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(ResponsiblePickComplete_Callback)));
    }

    private void PostulationPickComplete_Callback(VacantPostulationDisplayModel model)
    {
        ConcreteBindingContext.Postulation = model;
    }

    private void ResponsiblePickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;
    }
}
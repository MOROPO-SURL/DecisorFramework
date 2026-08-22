using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProjectProposalConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Models.Page.Configuration.ProjectProposalConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    public ProjectProposalConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> successAction, Models.Page.Configuration.ProjectProposalConfigurationPageModel model, Validators.ProjectProposalConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Propuesta de Proyecto";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectProposalInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ProgramId = ConcreteBindingContext.Program?.Id,
            CallForPropousalId = ConcreteBindingContext.CallForPropousal?.Id
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(documentFilePickResult.FileName))
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectProposalInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ProgramId = ConcreteBindingContext.Program?.Id,
            CallForPropousalId = ConcreteBindingContext.CallForPropousal?.Id
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = model.Document?.Id ?? System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(documentFilePickResult.FileName))
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
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

    private void ProgramPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProgramPickPage(ProgramPickComplete_Callback)));
    }

    private void CallForPropousalPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.CallForProposalPickPage(CallForPropousalPickComplete_Callback)));
    }

    private void DocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, [ "public.my.comic.extension" ] }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, [ "application/comics" ] }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf" ] }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, [ "cbr", "cbz" ] }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            documentFilePickResult = task.Result;

            using var stream = await documentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(documentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(documentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void ProgramPickComplete_Callback(Interop.API.Common.Models.Display.ProgramDisplayModel model)
    {
        ConcreteBindingContext.Program = model;
    }

    private void CallForPropousalPickComplete_Callback(Interop.API.Common.Models.Display.CallForProposalDisplayModel model)
    {
        ConcreteBindingContext.CallForPropousal = model;
    }
}
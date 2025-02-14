using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProformaConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProformaDisplayModel, Models.Page.Configuration.ProformaConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult rawDocumentFilePickResult;

    public ProformaConfigurationPage(System.Action<ProformaDisplayModel> successAction, Models.Page.Configuration.ProformaConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proforma de Contrato";

    protected override async System.Threading.Tasks.Task<ProformaDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProformasAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProformaInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Sections = []
        };

        if (rawDocumentFilePickResult != null)
        {
            using var stream = await rawDocumentFilePickResult.OpenReadAsync();

            model.RawDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = rawDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawDocumentFilePickResult.ContentType
            };

            stream.Read(model.RawDocument.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProformaDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProformasAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProformaInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Sections = []
        };

        if (rawDocumentFilePickResult != null)
        {
            using var stream = await rawDocumentFilePickResult.OpenReadAsync();

            model.RawDocument = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = ConcreteBindingContext.RawDocumentId ?? System.Guid.NewGuid(),
                Name = rawDocumentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = rawDocumentFilePickResult.ContentType,
            };

            stream.Read(model.RawDocument.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override void DisposeManagementResources()
    {
        base.DisposeManagementResources();

        rawDocumentFilePickResult = null;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void RawDocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo estático de proforma de contrato",
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

            rawDocumentFilePickResult = task.Result;

            using var stream = await rawDocumentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.RawDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(rawDocumentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(rawDocumentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }
}
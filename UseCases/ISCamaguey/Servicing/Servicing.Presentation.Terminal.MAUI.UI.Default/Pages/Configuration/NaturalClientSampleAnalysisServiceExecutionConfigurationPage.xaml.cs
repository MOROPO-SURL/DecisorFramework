using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientSampleAnalysisServiceExecutionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<NaturalClientSampleAnalysisServiceExecutionDisplayModel, NaturalClientSampleAnalysisServiceExecutionDisplayModel, Models.Page.Configuration.NaturalClientSampleAnalysisServiceExecutionConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    public NaturalClientSampleAnalysisServiceExecutionConfigurationPage(System.Action<NaturalClientSampleAnalysisServiceExecutionDisplayModel> successAction, Models.Page.Configuration.NaturalClientSampleAnalysisServiceExecutionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.NaturalClientSampleAnalysisServiceExecutionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Ejecución de Servicio";

    protected override async System.Threading.Tasks.Task<NaturalClientSampleAnalysisServiceExecutionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientSampleAnalysisServiceExecutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientSampleAnalysisServiceExecutionInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            OrderId = ConcreteBindingContext.Order.Id,
            AuthorId = ConcreteBindingContext.Author.Id
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

    protected override async System.Threading.Tasks.Task<NaturalClientSampleAnalysisServiceExecutionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientSampleAnalysisServiceExecutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientSampleAnalysisServiceExecutionInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            OrderId = ConcreteBindingContext.Order.Id,
            AuthorId = ConcreteBindingContext.Author.Id
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

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnApply(sender, args);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnCancel(sender, args);
    }

    private void OrderPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalClientSampleAnalysisServiceOrderPickPage(OrderPicked_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void DocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new Dictionary<Microsoft.Maui.Devices.DevicePlatform, IEnumerable<string>>
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

    private void OrderPicked_Callback(NaturalClientSampleAnalysisServiceOrderDisplayModel model)
    {
        ConcreteBindingContext.Order = model;

        hasChangesFlag = true;
    }

    private void AuthorPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }
}
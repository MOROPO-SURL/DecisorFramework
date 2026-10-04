using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PublicationResultConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PublicationResultDisplayModel, PublicationResultDisplayModel, Models.Page.Configuration.PublicationResultConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    public PublicationResultConfigurationPage(System.Action<PublicationResultDisplayModel> successAction, Models.Page.Configuration.PublicationResultConfigurationPageModel model, Validators.PublicationResultConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Publicación";

    protected override async System.Threading.Tasks.Task<PublicationResultDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PublicationResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PublicationResultInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            InternalResearchers = [.. ConcreteBindingContext.InternalResearchers],
            ExternalResearchers = [.. ConcreteBindingContext.ExternalResearchers],
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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

    protected override async System.Threading.Tasks.Task<PublicationResultDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PublicationResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PublicationResultInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            InternalResearchers = [.. ConcreteBindingContext.InternalResearchers],
            ExternalResearchers = [.. ConcreteBindingContext.ExternalResearchers],
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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

    private void ProjectPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProjectPickPage(ProjectPickComplete_Callback)));
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

    private void InternalResearcherAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.InternalResearcherPickPage(InternalResearcherPickComplete_Callback)));
    }

    private void InternalResearcherDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as InternalResearcherDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.InternalResearcherDetailPage(target, null));
    }

    private void ExternalResearcherAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ExternalResearcherPickPage(ExternalResearcherPickComplete_Callback)));
    }

    private void ExternalResearcherDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ExternalResearcherDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.ExternalResearcherDetailPage(target, null));
    }

    private void InternalResearcherRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as InternalResearcherDisplayModel;

                ConcreteBindingContext.InternalResearchers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ExternalResearcherRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ExternalResearcherDisplayModel;

                ConcreteBindingContext.ExternalResearchers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void ProjectPickComplete_Callback(ProjectDisplayModel model)
    {
        ConcreteBindingContext.Project = model;
    }

    private void InternalResearcherPickComplete_Callback(InternalResearcherDisplayModel model)
    {
        ConcreteBindingContext.InternalResearchers.Add(model);

        hasChangesFlag = true;
    }

    private void ExternalResearcherPickComplete_Callback(ExternalResearcherDisplayModel model)
    {
        ConcreteBindingContext.ExternalResearchers.Add(model);

        hasChangesFlag = true;
    }
}
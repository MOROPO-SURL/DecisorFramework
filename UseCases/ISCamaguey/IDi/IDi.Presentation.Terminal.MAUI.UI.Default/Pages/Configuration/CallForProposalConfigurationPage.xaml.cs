using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CallForProposalConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CallForProposalDisplayModel, Interop.API.Common.Models.Display.CallForProposalDisplayModel, Models.Page.Configuration.CallForProposalConfigurationPageModel>
{
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel> editionDocuments = [];
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel> incomingDocuments = [];
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> outgoingDocuments = [];

    public CallForProposalConfigurationPage(System.Action<Interop.API.Common.Models.Display.CallForProposalDisplayModel> successAction, Models.Page.Configuration.CallForProposalConfigurationPageModel model, Validators.CallForProposalConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Convocatoria";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CallForProposalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CallForProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.CallForProposalInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            FinancierId = ConcreteBindingContext.Financier.Id,
            ResearchAreas = [.. ConcreteBindingContext.ResearchAreas],
            IncomingDocuments = incomingDocuments
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CallForProposalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CallForProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.CallForProposalInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            FinancierId = ConcreteBindingContext.Financier.Id,
            ResearchAreas = [.. ConcreteBindingContext.ResearchAreas],
            IncomingDocuments = incomingDocuments,
            EditionDocuments = editionDocuments,
            OutgoingDocuments = outgoingDocuments
        };

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

    private void FinancierPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.FinancierPickPage(FinancierPickComplete_Callback)));
    }

    private void ResearchAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ResearchAreaPickPage(ResearchAreaPickComplete_Callback)));
    }

    private void ResearchAreaDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.ResearchAreaDetailPage(target, null));
    }

    private void ResearchAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta área de investigación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

                ConcreteBindingContext.ResearchAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
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
                var model = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Name = name,
                    ContentData = data,
                    ContentType = filePickResult.ContentType
                };

                incomingDocuments.Add(model);

                ConcreteBindingContext.Documents.Add(new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = name,
                    Extension = System.IO.Path.GetExtension(filePickResult.FileName),
                    Length = data.Length
                });

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

        var model = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.DocumentConfigurationPageModel(target);

        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.DocumentConfigurationPage(DocumentEditSuccess_Callback, model));
    }

    private void DocumentRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este documento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

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

    private void FinancierPickComplete_Callback(Interop.API.Common.Models.Display.FinancierDisplayModel model)
    {
        ConcreteBindingContext.Financier = model;
    }

    private void ResearchAreaPickComplete_Callback(Interop.API.Common.Models.Display.ResearchAreaDisplayModel model)
    {
        ConcreteBindingContext.ResearchAreas.Add(model);

        hasChangesFlag = true;
    }

    private void DocumentEditSuccess_Callback(Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel model)
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
            editionDocuments.Add(new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
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
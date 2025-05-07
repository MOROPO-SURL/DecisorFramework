using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProformaConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProformaDisplayModel, ProformaDisplayModel, Models.Page.Configuration.ProformaConfigurationPageModel>
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
            Sections = ConcreteBindingContext.Sections.Select(item => new Interop.API.Common.Models.Bridge.ProformaSectionClauseBridgeModel { Section = item.Section, Clauses = item.Clauses.ToArray() }).ToArray()
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
            Sections = ConcreteBindingContext.Sections.Select(item => new Interop.API.Common.Models.Bridge.ProformaSectionClauseBridgeModel { Section = item.Section, Clauses = item.Clauses.ToArray() }).ToArray()
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

    private void AddClauseButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SectionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception == null && !task.IsCanceled)
                {
                    var model = new Models.Page.Configuration.ProformaSectionClauseBridgeConfigurationPageModel(null)
                    {
                        AvailableSections = task.Result
                    };

                    this.NavigationPushPageAsync(new ProformaSectionClauseBridgeConfigurationPage(ClauseCreationSuccess_Callback, model));
                }
                else
                {
                    ((Caney.MVVM.Core.Models.Page.BasePageModel)BindingContext).IsBusy = false;

                    HandleException(task.Exception);
                }
            });
        });
    }

    private void ClauseCreationSuccess_Callback(Models.View.SectionClauseBridgeViewModel model)
    {
        var isSectionPresent = false;

        foreach (var item in ConcreteBindingContext.Sections)
        {
            if (item.Section.Id != model.Section.Id) continue;

            item.Clauses.Add(model.Clause);

            item.Clauses = new System.Collections.ObjectModel.ObservableCollection<ClauseDisplayModel>(item.Clauses.OrderBy(_item => _item.Priority));

            isSectionPresent = true;
        }

        if (!isSectionPresent)
        {
            var bridge = new Models.View.ProformaSectionClauseBridgeViewModel { Section = model.Section };

            bridge.Clauses.Add(model.Clause);

            ConcreteBindingContext.Sections.Add(bridge);

            ConcreteBindingContext.Sections = new System.Collections.ObjectModel.ObservableCollection<Models.View.ProformaSectionClauseBridgeViewModel>(ConcreteBindingContext.Sections.OrderBy(_item => _item.Section.Priority));
        }

        hasChangesFlag = true;
    }

    private void ClauseRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar la cláusula especificada de la presente proforma?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var clause = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as ClauseDisplayModel;

                var clausesGroup  = (sender as Microsoft.Maui.Controls.Button).Parent.Parent.BindingContext as Models.View.ProformaSectionClauseBridgeViewModel;

                clausesGroup.Clauses.Remove(clause);

                if (clausesGroup.Clauses.Count > 0) return;

                ConcreteBindingContext.Sections.Remove(clausesGroup);
            });
        });
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AssessmentConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.AssessmentDetailViewModel, Models.View.AssessmentDetailViewModel, Models.Page.Configuration.AssessmentConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    public AssessmentConfigurationPage(System.Action<Models.View.AssessmentDetailViewModel> successAction, Models.Page.Configuration.AssessmentConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.AssessmentConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Procesamiento de Muestra";

    protected override async System.Threading.Tasks.Task<Models.View.AssessmentDetailViewModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AssessmentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AssessmentInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            SampleId = ConcreteBindingContext.Sample.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            WorkPlanId = ConcreteBindingContext.WorkPlan.Id
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

        return new Models.View.AssessmentDetailViewModel(await apiConnectClient.GetAsync(model.Id), []);
    }

    protected override async System.Threading.Tasks.Task<Models.View.AssessmentDetailViewModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AssessmentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AssessmentInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            SampleId = ConcreteBindingContext.Sample.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            WorkPlanId = ConcreteBindingContext.WorkPlan.Id
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

        return new Models.View.AssessmentDetailViewModel(await apiConnectClient.GetAsync(model.Id), []);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnApply(sender, args);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnCancel(sender, args);
    }

    private void WorkPlanPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.WorkPlanPickPage(WorkPlanPicked_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void SamplePickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.WorkPlanSamplePickPage(ConcreteBindingContext.WorkPlan, ServiceOrderSamplePicked_Callback, ResearchSamplePicked_Callback, ProductionSamplePicked_Callback)));
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

    private void WorkPlanPicked_Callback(WorkPlanDisplayModel model)
    {
        ConcreteBindingContext.WorkPlan = model;

        hasChangesFlag = true;
    }

    private void AuthorPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void ServiceOrderSamplePicked_Callback(ServiceOrderSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.ServiceOrder,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        hasChangesFlag = true;

        ReloadAnalyses(model.Id);
    }

    private void ResearchSamplePicked_Callback(ResearchSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.Research,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        hasChangesFlag = true;

        ReloadAnalyses(model.Id);
    }

    private void ProductionSamplePicked_Callback(ProductionSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.Production,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        hasChangesFlag = true;

        ReloadAnalyses(model.Id);
    }

    private void ReloadAnalyses(System.Guid sampleId)
    {
        ConcreteBindingContext.Analyses.Clear();

        ConcreteBindingContext.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

        var analysesAPIConnectClient = new Interop.API.Connect.Clients.AnalysesAPIConnectClient(httpClientHelperProvider);
        var analisisQualityCheckAPIConnectClient = new Interop.API.Connect.Clients.AnalysisQualityChecksAPIConnectClient(httpClientHelperProvider);

        analysesAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AnalysisFilterModel { SampleId = sampleId }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (!task.IsCompletedSuccessfully)
                {
                    HandleException(task.Exception);

                    return;
                }

                AnalysisDisplayModel[] orderedItems = [.. task.Result.OrderBy(item => item.At)];

                foreach (var item in orderedItems)
                {
                    analisisQualityCheckAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.AnalysisQualityCheckFilterModel { AnalysisId = item.Id }).ContinueWith(_task =>
                    {
                        Dispatcher.Dispatch(() =>
                        {
                            if (!task.IsCompletedSuccessfully)
                            {
                                HandleException(_task.Exception);

                                return;
                            }

                            ConcreteBindingContext.Analyses.Add(new Models.View.AnalysisDetailViewModel(item, _task.Result));
                        });
                    });
                }
            });
        });
    }
}
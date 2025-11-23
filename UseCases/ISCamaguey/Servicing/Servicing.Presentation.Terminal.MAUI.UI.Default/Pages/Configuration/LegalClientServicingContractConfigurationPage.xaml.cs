using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientServicingContractConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    public LegalClientServicingContractConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> successAction, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel model, Validators.LegalClientServicingContractConfigurationValidator validator) : base(successAction, model, validator)
    {
		InitializeComponent();

        if (model.PaymentTerm != null)
        {
            for (int i = 0; i < model.AvailablePaymentTerms.Length; i++)
            {
                var current = model.AvailablePaymentTerms[i];

                if (model.PaymentTerm.Id != current.Id) continue;

                PaymentTermPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Contrato de Servicios a Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientServicingContractsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientServicingContractInputModel
        {
            Id = System.Guid.NewGuid(),
            StartAt = ConcreteBindingContext.StartAt,
            Index = ConcreteBindingContext.Index,
            Objective = ConcreteBindingContext.Objective,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            PaymentTermId = ConcreteBindingContext.PaymentTerm.Id,
            ClientId = ConcreteBindingContext.Client.Id,
            BankAccountId = ConcreteBindingContext.BankAccount.Id,
            TrainingServices = [.. ConcreteBindingContext.TrainingServices],
            SampleAnalysisServices = [.. ConcreteBindingContext.SampleAnalysisServices],
            GroundIntegralStudyServices = [.. ConcreteBindingContext.GroundIntegralStudyServices]
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = documentFilePickResult.ContentType
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientServicingContractsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientServicingContractInputModel
        {
            Id = ConcreteBindingContext.Id,
            StartAt = ConcreteBindingContext.StartAt,
            Index = ConcreteBindingContext.Index,
            Objective = ConcreteBindingContext.Objective,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            PaymentTermId = ConcreteBindingContext.PaymentTerm.Id,
            ClientId = ConcreteBindingContext.Client.Id,
            BankAccountId = ConcreteBindingContext.BankAccount.Id,
            TrainingServices = [.. ConcreteBindingContext.TrainingServices],
            SampleAnalysisServices = [.. ConcreteBindingContext.SampleAnalysisServices],
            GroundIntegralStudyServices = [.. ConcreteBindingContext.GroundIntegralStudyServices]
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = ConcreteBindingContext.DocumentId ?? System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = documentFilePickResult.ContentType,
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override void DisposeManagementResources()
    {
        base.DisposeManagementResources();

        documentFilePickResult = null;
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void BankAccountPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.LegalClientByContactBankAccountPickPage(BankAccountPickComplete_Callback, ConcreteBindingContext.Client.Contact)));
    }

    private void DocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".png", ".jpg", ".jpeg", ".bmp"] }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            documentFilePickResult = task.Result;

            using var stream = await documentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.Document = new DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(documentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(documentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void TrainingServiceAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.TrainingServicePickPage(TrainingServicePickComplete_Callback)));
    }

    private void SampleAnalysisServiceAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.SampleAnalysisServicePickPage(SampleAnalysisServicePickComplete_Callback)));
    }

    private void GroundIntegralStudyServiceAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.GroundIntegralStudyServicePickPage(GroundIntegralStudyServicePickComplete_Callback)));
    }

    private void TrainingServiceDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.TrainingServiceDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.TrainingServiceDetailPage(target, null));
    }

    private void SampleAnalysisServiceDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.SampleAnalysisServiceDetailPage(target, null));
    }

    private void GroundIntegralStudyServiceDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.GroundIntegralStudyServiceDetailPage(target, null));
    }

    private void TrainingServiceRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta servicio?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.TrainingServiceDisplayModel;

                ConcreteBindingContext.TrainingServices.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void SampleAnalysisServiceRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta servicio?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel;

                ConcreteBindingContext.SampleAnalysisServices.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void GroundIntegralStudyServiceRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta servicio?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel;

                ConcreteBindingContext.GroundIntegralStudyServices.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void BankAccountPickComplete_Callback(Framework.Decisor.Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel model)
    {
        ConcreteBindingContext.BankAccount = model;

        hasChangesFlag = true;
    }

    private void TrainingServicePickComplete_Callback(Interop.API.Common.Models.Display.TrainingServiceDisplayModel model)
    {
        ConcreteBindingContext.TrainingServices.Add(model);

        hasChangesFlag = true;
    }

    private void SampleAnalysisServicePickComplete_Callback(Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel model)
    {
        ConcreteBindingContext.SampleAnalysisServices.Add(model);

        hasChangesFlag = true;
    }

    private void GroundIntegralStudyServicePickComplete_Callback(Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel model)
    {
        ConcreteBindingContext.GroundIntegralStudyServices.Add(model);

        hasChangesFlag = true;
    }
}
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientPropertyLeasingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<LegalClientPropertyLeasingDisplayModel, LegalClientPropertyLeasingDisplayModel, Models.Page.Configuration.LegalClientPropertyLeasingConfigurationPageModel>
{
    public LegalClientPropertyLeasingConfigurationPage(System.Action<LegalClientPropertyLeasingDisplayModel> successAction, Models.Page.Configuration.LegalClientPropertyLeasingConfigurationPageModel model) : base(successAction, model, new Validators.LegalClientPropertyLeasingConfigurationValidator())
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

        if (model.CostCenter != null)
        {
            for (int i = 0; i < model.AvailableConstCenters.Length; i++)
            {
                var current = model.AvailableConstCenters[i];

                if (model.CostCenter.Id != current.Id) continue;

                CostCenterPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Arrendamiento de Inmueble a Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<LegalClientPropertyLeasingDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new LegalClientPropertyLeasingInputModel
        {
            Id = System.Guid.NewGuid(),
            PostulationId = ConcreteBindingContext.Postulation.Id,
            Index = ConcreteBindingContext.Index,
            Objective = ConcreteBindingContext.Objective,
            StartAt = ConcreteBindingContext.StartAt,
            PaymentTermId = ConcreteBindingContext.AvailablePaymentTerms[PaymentTermPicker.SelectedIndex].Id,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            Feed = ConcreteBindingContext.Feed,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            CostCenterId = ConcreteBindingContext.AvailableConstCenters[CostCenterPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            Contacts = [.. ConcreteBindingContext.Contacts]
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override System.Threading.Tasks.Task<LegalClientPropertyLeasingDisplayModel> PerformEditionAsync()
    {
        throw new System.InvalidOperationException();
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(MeetingAgreementPickComplete_Callback)));
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void WorkerAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(WorkerPickComplete_Callback)));
    }

    private void WorkerDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.PersonContactDetailPage(target, null));
    }

    private void WorkerRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este trabajador?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

                ConcreteBindingContext.Contacts.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void MeetingAgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }

    private void WorkerPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contacts.Add(model);
    }
}
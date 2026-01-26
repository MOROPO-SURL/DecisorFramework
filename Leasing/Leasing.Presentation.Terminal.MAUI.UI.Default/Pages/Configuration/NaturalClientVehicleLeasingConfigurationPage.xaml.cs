using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientVehicleLeasingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<NaturalClientVehicleLeasingDisplayModel, NaturalClientVehicleLeasingDisplayModel, Models.Page.Configuration.NaturalClientVehicleLeasingConfigurationPageModel>
{
    public NaturalClientVehicleLeasingConfigurationPage(System.Action<NaturalClientVehicleLeasingDisplayModel> successAction, Models.Page.Configuration.NaturalClientVehicleLeasingConfigurationPageModel model) : base(successAction, model, new Validators.NaturalClientVehicleLeasingConfigurationValidator())
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

    protected override string EntityTypeName => "Arrendamiento de Vehículo a Cliente Naturales";

    protected override async System.Threading.Tasks.Task<NaturalClientVehicleLeasingDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientVehicleLeasingInputModel
        {
            Id = System.Guid.NewGuid(),
            PostulationId = ConcreteBindingContext.Postulation.Id,
            Index = ConcreteBindingContext.Index,
            Objective = ConcreteBindingContext.Objective,
            OperativeLicenceCode = ConcreteBindingContext.OperativeLicenceCode,
            StartAt = ConcreteBindingContext.StartAt,
            PaymentTermId = ConcreteBindingContext.AvailablePaymentTerms[PaymentTermPicker.SelectedIndex].Id,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            Feed = ConcreteBindingContext.Feed,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            CostCenterId = ConcreteBindingContext.AvailableConstCenters[CostCenterPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingDriveLicences = [.. ConcreteBindingContext.DriveLicences.Select(item => new Interop.API.Common.Models.Input.DriveLicenceInputModel
            {
                Id = item.Id,
                ContactId = item.Contact.Id,
                Code = item.Code,
                Reference = item.Reference,
                ReleasedAt = item.ReleasedAt,
                ExpireAt = item.ExpireAt
            })]
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override System.Threading.Tasks.Task<NaturalClientVehicleLeasingDisplayModel> PerformEditionAsync()
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

    private void DriveLicenceCreationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new DriveLicenceConfigurationPage(DriveLicenceCreationComplete_Callback, new Models.Page.Configuration.DriveLicenceConfigurationPageModel(null)));
    }

    private void DriveLicenceEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DriveLicenceDisplayModel;

        this.NavigationPushPageAsync(new DriveLicenceConfigurationPage(DriveLicenceEditionComplete_Callback, new Models.Page.Configuration.DriveLicenceConfigurationPageModel(target)));
    }

    private void DriveLicenceRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este conductor?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DriveLicenceDisplayModel;

                ConcreteBindingContext.DriveLicences.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void MeetingAgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }

    private void DriveLicenceCreationComplete_Callback(DriveLicenceDisplayModel model)
    {
        if (ConcreteBindingContext.DriveLicences.Any(item => item.Contact.Id == model.Contact.Id))
        {
            DisplayAlert("Aviso", "Ya se ha definido este conductor.", "Aceptar");

            return;
        }

        ConcreteBindingContext.DriveLicences.Add(model);
    }

    private void DriveLicenceEditionComplete_Callback(DriveLicenceDisplayModel model)
    {
        ConcreteBindingContext.DriveLicences[ConcreteBindingContext.DriveLicences.IndexOf(model)] = model;
    }
}
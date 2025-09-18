using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientVehicleLeasingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<LegalClientVehicleLeasingDisplayModel, LegalClientVehicleLeasingDisplayModel, Models.Page.Configuration.LegalClientVehicleLeasingConfigurationPageModel>
{
    public LegalClientVehicleLeasingConfigurationPage(System.Action<LegalClientVehicleLeasingDisplayModel> successAction, Models.Page.Configuration.LegalClientVehicleLeasingConfigurationPageModel model) : base(successAction, model, new Validators.LegalClientVehicleLeasingConfigurationValidator())
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

    protected override string EntityTypeName => "Arrendamiento de Vehículo a Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<LegalClientVehicleLeasingDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientVehicleLeasingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new LegalClientVehicleLeasingInputModel
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
            Priority = ConcreteBindingContext.Priority,
            Contacts = [.. ConcreteBindingContext.Contacts]
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override System.Threading.Tasks.Task<LegalClientVehicleLeasingDisplayModel> PerformEditionAsync()
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

    private void MeetingAgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }
}
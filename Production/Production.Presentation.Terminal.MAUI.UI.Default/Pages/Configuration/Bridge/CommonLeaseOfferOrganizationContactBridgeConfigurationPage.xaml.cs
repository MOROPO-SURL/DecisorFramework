using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Bridge;

public partial class CommonLeaseOfferOrganizationContactBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel, Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel, Models.Page.Configuration.Bridge.CommonLeaseOfferOrganizationContactBridgeConfigurationPageModel>
{
    public CommonLeaseOfferOrganizationContactBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel> successAction, Models.Page.Configuration.Bridge.CommonLeaseOfferOrganizationContactBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Postulante Jurídico";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel
        {
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            Argument = ConcreteBindingContext.Argument
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel
        {
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            Argument = ConcreteBindingContext.Argument
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
    }
}
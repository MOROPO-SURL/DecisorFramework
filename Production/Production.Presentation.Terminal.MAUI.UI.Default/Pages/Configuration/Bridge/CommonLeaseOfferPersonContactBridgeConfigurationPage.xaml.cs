using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Bridge;

public partial class CommonLeaseOfferPersonContactBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel, Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel, Models.Page.Configuration.Bridge.CommonLeaseOfferPersonContactBridgeConfigurationPageModel>
{
    public CommonLeaseOfferPersonContactBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel> successAction, Models.Page.Configuration.Bridge.CommonLeaseOfferPersonContactBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.BusinessKind != null)
        {
            for (int i = 0; i < model.AvailableBusinessKinds.Length; i++)
            {
                var current = model.AvailableBusinessKinds[i];

                if (model.BusinessKind.Id != current.Id) continue;

                BusinessKindPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Postulante Natural";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel
        {
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.Bridge.CommonLeaseOfferPersonContactBridgeInputModel
        {
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
    }
}
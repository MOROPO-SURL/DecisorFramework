using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CommonLeaseOrganizationPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<CommonLeaseOrganizationPostulationDisplayModel, CommonLeaseOrganizationPostulationInputModel, Models.Page.Configuration.CommonLeaseOrganizationPostulationConfigurationPageModel>
{
    public CommonLeaseOrganizationPostulationConfigurationPage(System.Action<CommonLeaseOrganizationPostulationInputModel> successAction, Models.Page.Configuration.CommonLeaseOrganizationPostulationConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Postulante Jurídico";

    protected override System.Threading.Tasks.Task<CommonLeaseOrganizationPostulationInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new CommonLeaseOrganizationPostulationInputModel
        {
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            Argument = ConcreteBindingContext.Argument
        });
    }

    protected override System.Threading.Tasks.Task<CommonLeaseOrganizationPostulationInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new CommonLeaseOrganizationPostulationInputModel
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
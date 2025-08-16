using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleLeaseOrganizationPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleLeaseOrganizationPostulationDisplayModel, VehicleLeaseOrganizationPostulationDisplayModel, Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel>
{
    public VehicleLeaseOrganizationPostulationConfigurationPage(System.Action<VehicleLeaseOrganizationPostulationDisplayModel> successAction, Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Postulante Jurídico";

    protected override async System.Threading.Tasks.Task<VehicleLeaseOrganizationPostulationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeaseOrganizationPostulationInputModel
        {
            Id = System.Guid.NewGuid(),
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            Argument = ConcreteBindingContext.Argument
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<VehicleLeaseOrganizationPostulationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeaseOrganizationPostulationInputModel
        {
            Id = ConcreteBindingContext.Id,
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            StateIdentificationCode = ConcreteBindingContext.StateIdentificationCode,
            Argument = ConcreteBindingContext.Argument
        };

        await apiConnectClient.EditAsync(model);

        return null;
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
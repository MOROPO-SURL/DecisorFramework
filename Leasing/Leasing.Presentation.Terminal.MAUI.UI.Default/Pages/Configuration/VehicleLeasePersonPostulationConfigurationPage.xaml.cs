using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;


public partial class VehicleLeasePersonPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleLeasePersonPostulationDisplayModel, VehicleLeasePersonPostulationDisplayModel, Models.Page.Configuration.VehicleLeasePersonPostulationConfigurationPageModel>
{
    public VehicleLeasePersonPostulationConfigurationPage(System.Action<VehicleLeasePersonPostulationDisplayModel> successAction, Models.Page.Configuration.VehicleLeasePersonPostulationConfigurationPageModel model) : base(successAction, model)
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

        if (model.MainPostalContactItem != null)
        {
            for (int i = 0; i < model.Contact.Identity.PostalContacts.Length; i++)
            {
                var current = model.Contact.Identity.PostalContacts[i];

                if (model.MainPostalContactItem.Id != current.Id) continue;

                PostalContactItemPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Postulante Natural";

    protected override async System.Threading.Tasks.Task<VehicleLeasePersonPostulationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeasePersonPostulationInputModel
        {
            Id = System.Guid.NewGuid(),
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            MainPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[PostalContactItemPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<VehicleLeasePersonPostulationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new VehicleLeasePersonPostulationInputModel
        {
            Id = ConcreteBindingContext.Id,
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            MainPostalContactItemId = ConcreteBindingContext.Contact.Identity.PostalContacts[PostalContactItemPicker.SelectedIndex].Id,
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
        ConcreteBindingContext.TaxIdentificationNumber = model.PersonalIdentificationNumber;
    }
}
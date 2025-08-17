using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertyLeasePersonPostulationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PropertyLeasePersonPostulationDisplayModel, PropertyLeasePersonPostulationDisplayModel, Models.Page.Configuration.PropertyLeasePersonPostulationConfigurationPageModel>
{
    private readonly List<PropertySpaceLeasePropousalDisplayModel> incomingSpaces = [];
    private readonly List<PropertySpaceLeasePropousalDisplayModel> outgoingSpaces = [];

    public PropertyLeasePersonPostulationConfigurationPage(System.Action<PropertyLeasePersonPostulationDisplayModel> successAction, Models.Page.Configuration.PropertyLeasePersonPostulationConfigurationPageModel model) : base(successAction, model)
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

    protected override async System.Threading.Tasks.Task<PropertyLeasePersonPostulationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new PropertyLeasePersonPostulationInputModel
        {
            Id = System.Guid.NewGuid(),
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument,
            IncomingSpaces = incomingSpaces
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<PropertyLeasePersonPostulationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new PropertyLeasePersonPostulationInputModel
        {
            Id = ConcreteBindingContext.Id,
            OfferId = ConcreteBindingContext.OfferId,
            ContactId = ConcreteBindingContext.Contact.Id,
            TaxIdentificationNumber = ConcreteBindingContext.TaxIdentificationNumber,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            Argument = ConcreteBindingContext.Argument,
            IncomingSpaces = incomingSpaces,
            OutgoingSpaces = outgoingSpaces
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

    private void SpaceAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PropertySpaceForLeasePropousalPickPage(PropertySpacePickComplete_Callback, ConcreteBindingContext.Propousal.SpacePropousals.Except(ConcreteBindingContext.Spaces).Select(item => item.Space).ToArray())));
    }

    private void SpaceRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este espacio?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertySpaceLeasePropousalDisplayModel;

                var handled = false;

                foreach (var item in incomingSpaces)
                {
                    if (item.Id != target.Id) continue;

                    incomingSpaces.Remove(incomingSpaces.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outgoingSpaces.Add(target);
                }

                ConcreteBindingContext.Spaces.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void PropertySpacePickComplete_Callback(Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel model)
    {
        var target = ConcreteBindingContext.Propousal.SpacePropousals.First(item => item.Space.Id == model.Id);

        incomingSpaces.Add(target);

        ConcreteBindingContext.Spaces.Add(target);

        hasChangesFlag = true;
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
    }
}
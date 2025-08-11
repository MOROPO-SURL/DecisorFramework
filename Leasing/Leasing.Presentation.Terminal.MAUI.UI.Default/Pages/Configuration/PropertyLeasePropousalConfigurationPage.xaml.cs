using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertyLeasePropousalConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PropertyLeasePropousalDisplayModel, PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Input.PropertySpaceLeasePropousalInputModel> incomingSpaces = [];
    private readonly List<PropertySpaceLeasePropousalDisplayModel> outgoingSpaces = [];

    public PropertyLeasePropousalConfigurationPage(System.Action<PropertyLeasePropousalDisplayModel> successAction, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Propuesta de Arrendamiento de Inmueble";

    protected async override System.Threading.Tasks.Task<PropertyLeasePropousalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyLeasePropousalInputModel
        {
            Id = System.Guid.NewGuid(),
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            PropertyId = ConcreteBindingContext.Property.Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingSpaces = incomingSpaces
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<PropertyLeasePropousalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyLeasePropousalInputModel
        {
            Id = ConcreteBindingContext.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            PropertyId = ConcreteBindingContext.Property.Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingSpaces = incomingSpaces,
            OutgoingSpaces = outgoingSpaces
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void PropertyPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PropertyPickPage(PropertyPickComplete_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void SpacePropousalAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PropertySpaceForLeasePropousalPickPage(PropertySpacePickComplete_Callback, ConcreteBindingContext.Property, ConcreteBindingContext.SpacePropousals.ToArray())));
    }

    private void SpacePropousalRemotionButton_Clicked(object sender, System.EventArgs e)
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
                    outgoingSpaces.Add(new PropertySpaceLeasePropousalDisplayModel
                    {
                        Id = target.Id
                    });
                }

                ConcreteBindingContext.SpacePropousals.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void PropertyPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PropertyDisplayModel model)
    {
        if (ConcreteBindingContext.Property?.Id != model.Id)
        {
            var outgoingSpaces = ConcreteBindingContext.SpacePropousals;

            foreach (var item in incomingSpaces)
            {
                var target = outgoingSpaces.First(_item => _item.Id == item.Id);

                outgoingSpaces.Remove(target);
            }

            this.outgoingSpaces.AddRange(outgoingSpaces);

            ConcreteBindingContext.SpacePropousals.Clear();
        }

        ConcreteBindingContext.Property = model;
    }

    private void AuthorPickComplete_Callback(HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }

    private void PropertySpacePickComplete_Callback(Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel model)
    {
        var id = System.Guid.NewGuid();

        incomingSpaces.Add(new Interop.API.Common.Models.Input.PropertySpaceLeasePropousalInputModel { Id = id, PropertySpaceId = model.Id });

        ConcreteBindingContext.SpacePropousals.Add(new PropertySpaceLeasePropousalDisplayModel
        {
            Id = id,
            Space = model
        });

        hasChangesFlag = true;
    }
}
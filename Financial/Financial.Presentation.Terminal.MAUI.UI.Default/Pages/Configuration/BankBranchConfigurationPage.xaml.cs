using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class BankBranchConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.BankBranchDisplayModel>
{
    public BankBranchConfigurationPage(System.Action<Interop.API.Common.Models.Display.BankBranchDisplayModel> successAction, Models.Page.Configuration.BankBranchConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Agency != null)
        {
            for (int i = 0; i < model.AvailableAgencies.Length; i++)
            {
                var current = model.AvailableAgencies[i];

                if (model.Agency.Id != current.Id) continue;

                AgencyPicker.SelectedIndex = i;
                AgencyPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Sucursal Bancaria";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankBranchDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankBranchesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.BankBranchConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankBranchInputModel
        {
            Id = System.Guid.NewGuid(),
            Number = concreteBindingContext.Number,
            Priority = concreteBindingContext.Priority,
            AgencyId = concreteBindingContext.AvailableAgencies[AgencyPicker.SelectedIndex].Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankBranchDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankBranchesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.BankBranchConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.BankBranchInputModel
        {
            Id = concreteBindingContext.Id,
            Number = concreteBindingContext.Number,
            Priority = concreteBindingContext.Priority,
            AgencyId = concreteBindingContext.AvailableAgencies[AgencyPicker.SelectedIndex].Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
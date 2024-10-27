using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Pages.Configuration;

public partial class PurchaseSpentConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel>
{
	public PurchaseSpentConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel> successAction, Models.Page.Configuration.PurchaseSpentConfigurationPageModel model) : base(successAction, model)
	{
		InitializeComponent();
	}

    protected override string EntityTypeName => "Tipo de Gasto de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseSpentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseSpentConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseSpentInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseSpentDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseSpentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseSpentConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseSpentInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }
}
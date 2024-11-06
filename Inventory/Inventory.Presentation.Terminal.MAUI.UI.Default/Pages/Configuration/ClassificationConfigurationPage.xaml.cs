using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ClassificationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.ClassificationDisplayModel>
{
    public ClassificationConfigurationPage(System.Action<Interop.API.Common.Models.Display.ClassificationDisplayModel> successAction, Models.Page.Configuration.ClassificationConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Clasificación";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ClassificationDisplayModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ClassificationConfigurationPageModel)BindingContext;

        if (concreteBindingContext.ProductConfigurationPageModel.Id == default)
        {
            return new Interop.API.Common.Models.Display.ClassificationDisplayModel
            {
                Id = System.Guid.NewGuid(),
                Name = concreteBindingContext.Name,
                Description = concreteBindingContext.Description,
                Priority = concreteBindingContext.Priority
            };
        }

        var apiConnectClient = new Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ClassificationInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ProductId = concreteBindingContext.ProductConfigurationPageModel.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ClassificationDisplayModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ClassificationConfigurationPageModel)BindingContext;

        if (concreteBindingContext.ProductConfigurationPageModel.Id == default)
        {
            return new Interop.API.Common.Models.Display.ClassificationDisplayModel
            {
                Id = concreteBindingContext.Id,
                Name = concreteBindingContext.Name,
                Description = concreteBindingContext.Description,
                Priority = concreteBindingContext.Priority
            };
        }

        var apiConnectClient = new Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ClassificationInputModel
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

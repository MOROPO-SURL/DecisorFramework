using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class UnitMeasurementConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>
{
    public UnitMeasurementConfigurationPage(System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> successAction, Models.Page.Configuration.UnitMeasurementConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Unidad de Medida";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.UnitMeasurementConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.UnitMeasurementInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Symbol = concreteBindingContext.Symbol,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.UnitMeasurementConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.UnitMeasurementInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Symbol = concreteBindingContext.Symbol,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }
}
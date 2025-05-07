namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductWarehousingDecreaseBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel, Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel, Models.Page.Configuration.ProductWarehousingDecreaseBridgeConfigurationPageModel>
{
    public ProductWarehousingDecreaseBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel> successAction, Models.Page.Configuration.ProductWarehousingDecreaseBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (!ConcreteBindingContext.OnEditionMode) hasChangesFlag = true;
    }

    protected override string EntityTypeName => "Margen de Merma";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel
        {
            Kind = ConcreteBindingContext.Kind,
            MinDecrease = ConcreteBindingContext.MinDecrease,
            MaxDecrease = ConcreteBindingContext.MaxDecrease
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.ProductWarehousingDecreaseBridgeModel
        {
            Kind = ConcreteBindingContext.Kind,
            MinDecrease = ConcreteBindingContext.MinDecrease,
            MaxDecrease = ConcreteBindingContext.MaxDecrease
        });
    }
}
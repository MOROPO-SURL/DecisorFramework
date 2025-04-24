namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class ProyectionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProyectionDisplayModel, Models.Page.Configuration.ProyectionConfigurationPageModel>
{
    public ProyectionConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProyectionDisplayModel> successAction, Models.Page.Configuration.ProyectionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proyección";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProyectionDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProyectionDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProyectionDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProyectionDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description
        });
    }
}
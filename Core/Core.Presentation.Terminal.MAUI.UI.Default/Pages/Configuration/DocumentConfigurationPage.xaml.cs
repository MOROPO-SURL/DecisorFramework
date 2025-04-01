namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DocumentConfigurationPage : UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DocumentDisplayModel, Models.Page.Configuration.DocumentConfigurationPageModel>
{
    public DocumentConfigurationPage(System.Action<Interop.API.Common.Models.Display.DocumentDisplayModel> successAction, Models.Page.Configuration.DocumentConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Documento";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DocumentDisplayModel> PerformCreationAsync()
    {
        throw new System.NotImplementedException();
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DocumentDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.DocumentDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description
        });
    }
}
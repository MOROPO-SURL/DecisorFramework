namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProjectSpecificObjectiveConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel, Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel, Models.Page.Configuration.ProjectSpecificObjectiveConfigurationPageModel>
{
    public ProjectSpecificObjectiveConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel> successAction, Models.Page.Configuration.ProjectSpecificObjectiveConfigurationPageModel model, Validators.ProjectSpecificObjectiveConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Objetivo Específico";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }
}
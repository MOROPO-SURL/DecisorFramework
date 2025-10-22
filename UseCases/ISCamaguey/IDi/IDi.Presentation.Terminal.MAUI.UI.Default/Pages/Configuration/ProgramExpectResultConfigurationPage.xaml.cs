namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProgramExpectResultConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel, Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel, Models.Page.Configuration.ProgramExpectResultConfigurationPageModel>
{
    public ProgramExpectResultConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel> successAction, Models.Page.Configuration.ProgramExpectResultConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ProgramExpectResultConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Prioridad de Programa";

    protected override bool IsNotificationRequired => false;

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Index = ConcreteBindingContext.Index,
            Description = ConcreteBindingContext.Description
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Index = ConcreteBindingContext.Index,
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
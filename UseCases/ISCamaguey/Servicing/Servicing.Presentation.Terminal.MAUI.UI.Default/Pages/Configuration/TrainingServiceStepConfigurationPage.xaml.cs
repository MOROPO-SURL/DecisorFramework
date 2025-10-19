namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class TrainingServiceStepConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.TrainingServiceStepDisplayModel, Interop.API.Common.Models.Input.TrainingServiceStepInputModel, Models.Page.Configuration.TrainingServiceStepConfigurationPageModel>
{
    public TrainingServiceStepConfigurationPage(System.Action<Interop.API.Common.Models.Input.TrainingServiceStepInputModel> successAction, Models.Page.Configuration.TrainingServiceStepConfigurationPageModel model, Validators.TrainingServiceStepConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etapa de Servicio de Capacitación";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.TrainingServiceStepInputModel> PerformCreationAsync()
    {
        var model = new Interop.API.Common.Models.Input.TrainingServiceStepInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        return System.Threading.Tasks.Task.FromResult(model);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.TrainingServiceStepInputModel> PerformEditionAsync()
    {
        var model = new Interop.API.Common.Models.Input.TrainingServiceStepInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        return System.Threading.Tasks.Task.FromResult(model);
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
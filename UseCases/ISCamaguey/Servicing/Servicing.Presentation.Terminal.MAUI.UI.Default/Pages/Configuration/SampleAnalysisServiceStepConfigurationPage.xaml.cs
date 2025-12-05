namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class SampleAnalysisServiceStepConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel, Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel, Models.Page.Configuration.SampleAnalysisServiceStepConfigurationPageModel>
{
    public SampleAnalysisServiceStepConfigurationPage(System.Action<Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel> successAction, Models.Page.Configuration.SampleAnalysisServiceStepConfigurationPageModel model, Validators.SampleAnalysisServiceStepConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etapa de Servicio de Procesamiento de Muestras";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel> PerformCreationAsync()
    {
        var model = new Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        return System.Threading.Tasks.Task.FromResult(model);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel> PerformEditionAsync()
    {
        var model = new Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel
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
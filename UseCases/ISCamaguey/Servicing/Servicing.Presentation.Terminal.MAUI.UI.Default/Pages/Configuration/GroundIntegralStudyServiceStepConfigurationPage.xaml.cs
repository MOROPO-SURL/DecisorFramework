namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class GroundIntegralStudyServiceStepConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel, Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel, Models.Page.Configuration.GroundIntegralStudyServiceStepConfigurationPageModel>
{
    public GroundIntegralStudyServiceStepConfigurationPage(System.Action<Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel> successAction, Models.Page.Configuration.GroundIntegralStudyServiceStepConfigurationPageModel model, Validators.GroundIntegralStudyServiceStepConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etapa de Servicio de Estudio Integral de Suelo";

    protected override bool IsNotificationRequired => false;

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel> PerformCreationAsync()
    {
        var model = new Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        return System.Threading.Tasks.Task.FromResult(model);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel> PerformEditionAsync()
    {
        var model = new Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel
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
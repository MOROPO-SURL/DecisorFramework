using FluentValidation;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class WorkPlanConfigurationValidator : AbstractValidator<Models.Page.Configuration.WorkPlanConfigurationPageModel>
{
    private const string SAMPLE_REQUIRED_MESSAGE = "Debe definir al menos un muestra, ya sea de órden de servicio, de investigación o de producción";

    public WorkPlanConfigurationValidator()
    {
        RuleFor(model => model.WorkingGroup).NotNull().NotEmpty().WithName("Equipo");

        RuleFor(model => model.ServiceOrderSamples)
            .Must((model, field) => field.Any() || model.ResearchSamples.Any() || model.ProductionSamples.Any())
            .WithMessage(SAMPLE_REQUIRED_MESSAGE);

        RuleFor(model => model.ResearchSamples)
            .Must((model, field) => field.Any() || model.ServiceOrderSamples.Any() || model.ProductionSamples.Any())
            .WithMessage(SAMPLE_REQUIRED_MESSAGE);

        RuleFor(model => model.ProductionSamples)
            .Must((model, field) => field.Any() || model.ServiceOrderSamples.Any() || model.ResearchSamples.Any())
            .WithMessage(SAMPLE_REQUIRED_MESSAGE);
    }
}
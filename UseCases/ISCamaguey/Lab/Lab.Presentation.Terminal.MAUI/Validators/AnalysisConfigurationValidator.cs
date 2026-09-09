using FluentValidation;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public sealed class AnalysisConfigurationValidator : AbstractValidator<AnalysisConfigurationPageModel>
{
    public AnalysisConfigurationValidator()
    {
        RuleFor(model => model.WorkPlan).NotNull().WithName("Plan de trabajo");

        RuleFor(model => model.Sample).NotNull().WithName("Muestra");

        RuleFor(model => model.Technique).NotNull().WithName("Técnica");

        RuleFor(model => model.Description).NotEmpty().WithName("Observaciones");
    }
}

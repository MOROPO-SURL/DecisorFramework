using FluentValidation;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public sealed class AssessmentQualityCheckConfigurationValidator : AbstractValidator<AssessmentQualityCheckConfigurationPageModel>
{
    public AssessmentQualityCheckConfigurationValidator()
    {
        RuleFor(model => model.Assessment).NotNull().WithName("Procesamiento de Muestra");

        RuleFor(model => model.Author).NotNull().WithName("Especialista");

        RuleFor(model => model.Description).NotEmpty().WithName("Conclusiones");
    }
}
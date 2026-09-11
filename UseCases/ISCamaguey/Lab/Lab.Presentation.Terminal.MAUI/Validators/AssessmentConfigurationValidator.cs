using FluentValidation;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public sealed class AssessmentConfigurationValidator : AbstractValidator<AssessmentConfigurationPageModel>
{
    public AssessmentConfigurationValidator()
    {
        RuleFor(model => model.WorkPlan).NotNull().WithName("Plan de trabajo");

        RuleFor(model => model.Sample).NotNull().WithName("Muestra");

        RuleFor(model => model.Author).NotNull().WithName("Especialista");

        RuleFor(model => model.Description).NotEmpty().WithName("Conclusiones");

        RuleFor(model => model.Analyses).NotEmpty().WithMessage("Debe seleccionar una muestra a la que se le hayan realizado análisis.");

        RuleFor(model => model.Document)
            .NotNull()
            .WithName("Documento");
    }
}
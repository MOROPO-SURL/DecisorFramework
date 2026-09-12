using FluentValidation;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public sealed class AnalysisQualityCheckConfigurationValidator : AbstractValidator<AnalysisQualityCheckConfigurationPageModel>
{
    public AnalysisQualityCheckConfigurationValidator()
    {
        RuleFor(model => model.Analysis).NotNull().WithName("Análisis de Muestra");

        RuleFor(model => model.Author).NotNull().WithName("Especialista");

        RuleFor(model => model.Description).NotEmpty().WithName("Conclusiones");
    }
}

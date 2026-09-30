using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ScientificTechnicalResultIntroductionConfigurationValidator : AbstractValidator<Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel>
{
    public ScientificTechnicalResultIntroductionConfigurationValidator()
    {
        RuleFor(model => model.Scenary)
            .NotEmpty()
            .WithName("Escenario");

        RuleFor(model => model.Result)
            .NotNull()
            .WithName("Resultado CTI");
    }
}
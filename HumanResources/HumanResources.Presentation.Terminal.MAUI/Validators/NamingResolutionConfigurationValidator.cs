using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class NamingResolutionConfigurationValidator : AbstractValidator<Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public NamingResolutionConfigurationValidator()
    {
        RuleFor(model => model.Candidate)
            .NotNull()
            .WithName("Nombrado(a)");

        RuleFor(model => model.Summary)
            .NotEmpty()
            .MaximumLength(2048)
            .WithName("Resumen");
    }
}

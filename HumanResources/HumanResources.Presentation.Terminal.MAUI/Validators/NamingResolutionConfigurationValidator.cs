using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class NamingResolutionConfigurationValidator : AbstractValidator<Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public NamingResolutionConfigurationValidator()
    {
        RuleFor(model => model.Index)
            .GreaterThan(0)
            .WithName("Número de resolución");

        RuleFor(model => model.AdmitionPropousal)
            .NotNull()
            .WithName("Propuesta de admisión");

        RuleFor(model => model.Summary)
            .NotEmpty()
            .MaximumLength(2048)
            .WithName("Resumen");
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class DesignationResolutionConfigurationValidator : AbstractValidator<Models.Page.Configuration.DesignationResolutionConfigurationPageModel>
{
    public DesignationResolutionConfigurationValidator()
    {
        RuleFor(model => model.Contact)
            .NotNull()
            .WithName("Designado(a)");

        RuleFor(model => model.Vacant)
            .NotNull()
            .WithName("Puesto");

        RuleFor(model => model.Summary)
            .NotEmpty()
            .MaximumLength(2048)
            .WithName("Resumen");
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class WorkforceConfigurationValidator : AbstractValidator<Models.Page.Configuration.WorkforceConfigurationPageModel>
{
    public WorkforceConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(120)
            .WithName("Nombre");

        RuleFor(model => model.OrganizationalStructure)
            .NotNull()
            .WithName("Estructura organizacional");
    }
}

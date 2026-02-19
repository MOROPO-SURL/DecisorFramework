using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class OrganizationalStructureConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationalStructureConfigurationPageModel>
{
    public OrganizationalStructureConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(255)
            .WithName("Nombre");

        RuleFor(model => model.OrganizationalStructuringUnitConfiguration)
            .NotNull()
            .WithName("Árbol de Unidades Organizativas");
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class OrganizationalUnitConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationalUnitConfigurationPageModel>
{
    public OrganizationalUnitConfigurationValidator()
    {
        RuleFor(entity => entity.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithName("Nombre");

        RuleFor(entity => entity.Name)
            .MaximumLength(1024)
            .WithName("Descripción");
    }
}
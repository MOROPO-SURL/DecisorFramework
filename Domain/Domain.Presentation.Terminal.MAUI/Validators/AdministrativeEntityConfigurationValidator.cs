using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class AdministrativeEntityConfigurationValidator : AbstractValidator<Models.Page.Configuration.AdministrativeEntityConfigurationPageModel>
{
    public AdministrativeEntityConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.OrganizationalStructure)
            .NotNull()
            .WithName("Estructura Organizacional");
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class StructureConfigurationValidator : AbstractValidator<Models.Page.Configuration.StructureConfigurationPageModel>
{
    public StructureConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");
    }
}

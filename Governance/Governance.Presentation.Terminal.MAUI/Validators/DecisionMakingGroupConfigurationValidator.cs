using FluentValidation;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Validators;

public class DecisionMakingGroupConfigurationValidator : AbstractValidator<Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
{
    public DecisionMakingGroupConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(model => model.AdministrativeEntity)
            .NotNull()
            .WithName("Entidad Administrativa");

        RuleFor(model => model.Leader)
            .NotNull()
            .WithName("Decisor Superior");
    }
}

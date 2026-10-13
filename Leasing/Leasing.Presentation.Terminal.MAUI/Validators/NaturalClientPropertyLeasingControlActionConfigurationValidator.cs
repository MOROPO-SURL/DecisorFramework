using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public sealed class NaturalClientPropertyLeasingControlActionConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientPropertyLeasingControlActionConfigurationPageModel>
{
    public NaturalClientPropertyLeasingControlActionConfigurationValidator()
    {
        RuleFor(model => model.Description)
            .NotEmpty()
            .WithName("Descripción");

        RuleFor(model => model.SupervisionGroup)
            .NotNull()
            .WithName("Grupo de Supervición");

        RuleFor(model => model.Leasing)
            .NotEmpty()
            .WithName("Contrato");
    }
}

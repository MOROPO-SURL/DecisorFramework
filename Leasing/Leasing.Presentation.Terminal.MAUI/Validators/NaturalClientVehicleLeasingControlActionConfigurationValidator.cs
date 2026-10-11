using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public sealed class NaturalClientVehicleLeasingControlActionConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel>
{
    public NaturalClientVehicleLeasingControlActionConfigurationValidator()
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

using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public sealed class LegalClientVehicleLeasingControlActionConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientVehicleLeasingControlActionConfigurationPageModel>
{
    public LegalClientVehicleLeasingControlActionConfigurationValidator()
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

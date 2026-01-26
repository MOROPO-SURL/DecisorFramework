using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public class DriveLicenceVehicleKindBridgeConfigurationValidator : AbstractValidator<Models.Page.Configuration.DriveLicenceVehicleKindBridgeConfigurationPageModel>
{
    public DriveLicenceVehicleKindBridgeConfigurationValidator()
    {
        RuleFor(model => model.Stern)
            .NotNull()
            .WithName("Tipo de Vehículo");

        RuleFor(model => model.Category).NotNull();

        RuleFor(model => model.Specification).MaximumLength(100);
    }
}

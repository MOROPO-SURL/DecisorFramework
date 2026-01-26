using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientVehicleLeasingConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientVehicleLeasingConfigurationPageModel>
    {
        public NaturalClientVehicleLeasingConfigurationValidator()
        {
            RuleFor(model => model.Objective).NotEmpty();

            RuleFor(model => model.OperativeLicenceCode).NotEmpty();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.CostCenter).NotNull();

            RuleFor(model => model.DurationUnitCount).NotEmpty().GreaterThan(0);

            RuleFor(model => model.DurationUnitMeasureKind).NotNull();

            RuleFor(model => model.Feed).NotEmpty().GreaterThan(0);

            RuleFor(model => model.PaymentTerm).NotNull();

            RuleFor(model => model.DriveLicences).NotEmpty().WithName("Conductores");
        }
    }
}

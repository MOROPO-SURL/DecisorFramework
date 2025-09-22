using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientVehicleLeasingConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientVehicleLeasingConfigurationPageModel>
    {
        public LegalClientVehicleLeasingConfigurationValidator()
        {
            RuleFor(model => model.Objective).NotNull().NotEmpty();

            RuleFor(model => model.OperativeLicenceCode).NotNull().NotEmpty();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.CostCenter).NotNull();

            RuleFor(model => model.DurationUnitCount).NotNull().GreaterThan(0);

            RuleFor(model => model.DurationUnitMeasureKind).NotNull();

            RuleFor(model => model.Feed).NotNull().GreaterThan(0);

            RuleFor(model => model.PaymentTerm).NotNull();
        }
    }
}

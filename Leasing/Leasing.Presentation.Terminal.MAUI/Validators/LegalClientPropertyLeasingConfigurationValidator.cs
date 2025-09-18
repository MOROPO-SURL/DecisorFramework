using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientPropertyLeasingConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientPropertyLeasingConfigurationPageModel>
    {
        public LegalClientPropertyLeasingConfigurationValidator()
        {
            RuleFor(model => model.Objective).NotNull().NotEmpty();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.DurationUnitCount).NotNull().GreaterThan(0);

            RuleFor(model => model.DurationUnitMeasureKind).NotNull();

            RuleFor(model => model.Feed).NotNull().GreaterThan(0);

            RuleFor(model => model.PaymentTerm).NotNull();
        }
    }
}

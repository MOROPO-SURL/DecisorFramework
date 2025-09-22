using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientPropertyLeasingConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientPropertyLeasingConfigurationPageModel>
    {
        public NaturalClientPropertyLeasingConfigurationValidator()
        {
            RuleFor(model => model.Objective).NotNull().NotEmpty();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.CostCenter).NotNull();

            RuleFor(model => model.DurationUnitCount).NotNull().GreaterThan(0);

            RuleFor(model => model.DurationUnitMeasureKind).NotNull();

            RuleFor(model => model.Feed).NotNull().GreaterThan(0);

            RuleFor(model => model.PaymentTerm).NotNull();
        }
    }
}

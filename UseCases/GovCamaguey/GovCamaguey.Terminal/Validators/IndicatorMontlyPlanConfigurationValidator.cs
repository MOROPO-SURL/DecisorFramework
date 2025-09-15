using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class IndicatorMontlyPlanConfigurationValidator : AbstractValidator<Models.Page.Configuration.IndicatorMontlyPlanConfigurationPageModel>
    {
        public IndicatorMontlyPlanConfigurationValidator()
        {
            RuleFor(model => model.YearMonth)
                .NotNull();

            RuleFor(model => model.Amount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}

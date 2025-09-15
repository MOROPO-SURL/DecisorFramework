using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class IndicatorConfigurationValidator : AbstractValidator<Models.Page.Configuration.IndicatorConfigurationPageModel>
    {
        public IndicatorConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Amount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}

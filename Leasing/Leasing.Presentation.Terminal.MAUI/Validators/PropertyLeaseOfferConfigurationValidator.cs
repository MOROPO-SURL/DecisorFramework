using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class PropertyLeaseOfferConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyLeaseOfferConfigurationPageModel>
    {
        public PropertyLeaseOfferConfigurationValidator()
        {
            RuleFor(model => model.Propousal).NotNull();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class VehicleLeaseOfferConfigurationValidator : AbstractValidator<Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>
    {
        public VehicleLeaseOfferConfigurationValidator()
        {
            RuleFor(model => model.Propousal).NotNull();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

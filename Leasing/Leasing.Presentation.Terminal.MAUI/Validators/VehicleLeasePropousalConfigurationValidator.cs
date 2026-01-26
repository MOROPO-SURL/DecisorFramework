using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class VehicleLeasePropousalConfigurationValidator : AbstractValidator<Models.Page.Configuration.VehicleLeasePropousalConfigurationPageModel>
    {
        public VehicleLeasePropousalConfigurationValidator()
        {
            RuleFor(model => model.Vehicle).NotNull();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.Author).NotNull();

            RuleFor(model => model.Description).NotEmpty();

            RuleFor(model => model.BaselineAmount).NotEmpty().GreaterThan(0);

            RuleFor(model => model.BaselineCurrency).NotNull();
        }
    }
}

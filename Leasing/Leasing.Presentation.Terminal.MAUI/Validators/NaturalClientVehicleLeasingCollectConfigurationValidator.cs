using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientVehicleLeasingCollectConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientVehicleLeasingCollectConfigurationPageModel>
    {
        public NaturalClientVehicleLeasingCollectConfigurationValidator()
        {
            RuleFor(entity => entity.Amount).GreaterThan(0);

            RuleFor(entity => entity.Leasing).NotNull();
        }
    }
}

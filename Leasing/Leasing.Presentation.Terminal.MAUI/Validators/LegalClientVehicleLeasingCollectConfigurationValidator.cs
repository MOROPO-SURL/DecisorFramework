using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientVehicleLeasingCollectConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientVehicleLeasingCollectConfigurationPageModel>
    {
        public LegalClientVehicleLeasingCollectConfigurationValidator()
        {
            RuleFor(entity => entity.Amount).GreaterThan(0);

            RuleFor(entity => entity.Leasing).NotNull();
        }
    }
}
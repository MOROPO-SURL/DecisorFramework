using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientPropertyLeasingCollectConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientPropertyLeasingCollectConfigurationPageModel>
    {
        public LegalClientPropertyLeasingCollectConfigurationValidator()
        {
            RuleFor(entity => entity.Amount).GreaterThan(0);

            RuleFor(entity => entity.Leasing).NotNull();
        }
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientPropertyLeasingCollectConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientPropertyLeasingCollectConfigurationPageModel>
    {
        public NaturalClientPropertyLeasingCollectConfigurationValidator()
        {
            RuleFor(entity => entity.Amount).GreaterThan(0);

            RuleFor(entity => entity.Leasing).NotNull();
        }
    }
}

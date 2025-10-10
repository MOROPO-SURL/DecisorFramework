using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class CurrencyConfigurationValidator : AbstractValidator<Models.Page.Configuration.CurrencyConfigurationPageModel>
    {
        public CurrencyConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Symbol).NotNull().NotEmpty();
        }
    }
}

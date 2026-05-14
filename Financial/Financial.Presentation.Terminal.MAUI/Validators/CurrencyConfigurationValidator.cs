using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class CurrencyConfigurationValidator : AbstractValidator<Models.Page.Configuration.CurrencyConfigurationPageModel>
    {
        public CurrencyConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithName("Nombre");

            RuleFor(model => model.Symbol)
                .NotEmpty()
                .WithName("Símbolo");
        }
    }
}

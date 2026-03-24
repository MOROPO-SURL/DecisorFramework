using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class BankAccountConfigurationValidator : AbstractValidator<Models.Page.Configuration.BankAccountConfigurationPageModel>
    {
        public BankAccountConfigurationValidator()
        {
            RuleFor(model => model.Branch)
                .NotNull()
                .WithName("Sucursal");

            RuleFor(model => model.Currency)
                .NotNull()
                .WithName("Moneda");

            RuleFor(model => model.Number)
                .NotEmpty()
                .Matches("^[0-9]+$")
                .WithName("Número");

            RuleFor(model => model.Holder)
                .NotEmpty()
                .WithName("Titular");
        }
    }
}

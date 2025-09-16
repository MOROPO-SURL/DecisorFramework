using FluentValidation;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientConfigurationPageModel>
    {
        public LegalClientConfigurationValidator()
        {
            RuleFor(model => model.Contact)
                .NotNull();

            RuleFor(model => model.Representative)
                .NotNull();

            RuleFor(model => model.MainPostalContact)
                .NotNull();

            RuleFor(model => model.TaxIdentificationNumber)
                .NotNull()
                .Matches("^[0-9]+$");

            RuleFor(model => model.DefaultPaymentTerm)
                .NotNull();

            RuleFor(model => model.BankAccounts)
                .NotEmpty();
        }
    }
}

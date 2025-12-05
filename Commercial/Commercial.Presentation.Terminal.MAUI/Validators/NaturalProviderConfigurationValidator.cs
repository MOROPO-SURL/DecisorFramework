using FluentValidation;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Validators
{
    public class NaturalProviderConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalProviderConfigurationPageModel>
    {
        public NaturalProviderConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();

            RuleFor(model => model.MainPostalContact).NotNull();

            RuleFor(model => model.PersonalIdentificationNumber)
                .NotNull()
                .Matches("^[0-9]{11}$");

            RuleFor(model => model.BusinessKind).NotNull();

            RuleFor(model => model.DefaultPaymentTerm).NotNull();

            RuleFor(model => model.BankAccounts).NotEmpty();
        }
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class BankAccountConfigurationValidator : AbstractValidator<Models.Page.Configuration.BankAccountConfigurationPageModel>
    {
        public BankAccountConfigurationValidator()
        {
            RuleFor(model => model.Branch).NotNull();

            RuleFor(model => model.Currency).NotNull();

            RuleFor(model => model.Number).NotNull().NotEmpty().Matches("^[0-9]+$");

            RuleFor(model => model.Holder).NotNull().NotEmpty();
        }
    }
}

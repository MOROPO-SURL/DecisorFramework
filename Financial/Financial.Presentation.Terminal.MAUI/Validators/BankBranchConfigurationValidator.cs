using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class BankBranchConfigurationValidator : AbstractValidator<Models.Page.Configuration.BankBranchConfigurationPageModel>
    {
        public BankBranchConfigurationValidator()
        {
            RuleFor(model => model.Number)
                .NotNull().GreaterThan(0)
                .WithName("Número");

            RuleFor(model => model.Agency)
                .NotNull()
                .WithName("Agencia");
        }
    }
}

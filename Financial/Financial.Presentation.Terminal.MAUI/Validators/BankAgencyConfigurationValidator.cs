using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class BankAgencyConfigurationValidator : AbstractValidator<Models.Page.Configuration.BankAgencyConfigurationPageModel>
    {
        public BankAgencyConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithName("Nombre");
        }
    }
}

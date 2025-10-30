using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseSpentConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseSpentConfigurationPageModel>
    {
        public PurchaseSpentConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

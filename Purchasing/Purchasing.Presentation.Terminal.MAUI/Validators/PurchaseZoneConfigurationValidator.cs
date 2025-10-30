using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseZoneConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseZoneConfigurationPageModel>
    {
        public PurchaseZoneConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

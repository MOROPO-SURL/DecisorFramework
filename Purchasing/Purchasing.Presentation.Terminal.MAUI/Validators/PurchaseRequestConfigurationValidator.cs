using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseRequestConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseRequestConfigurationPageModel>
    {
        public PurchaseRequestConfigurationValidator()
        {
            RuleFor(model => model.Argument).NotNull().NotEmpty();

            RuleFor(model => model.Author).NotNull();

            RuleFor(model => model.ExpectedProductAdquisitions).NotEmpty();
        }
    }
}

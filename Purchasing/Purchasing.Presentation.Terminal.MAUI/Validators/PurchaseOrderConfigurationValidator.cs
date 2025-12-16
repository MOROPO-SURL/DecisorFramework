using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseOrderConfigurationPageModel>
    {
        public PurchaseOrderConfigurationValidator()
        {
            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.Responsible).NotNull();

            RuleFor(model => model.Zone).NotNull();

            RuleFor(model => model.ExpectedProductResults).NotEmpty();

            RuleFor(model => model.AdvanceRequired).Must((model, value) =>
            {
                if (!model.HasAdvanceRequired)
                {
                    return true;
                }

                return model.AdvanceRequired > 0;
            });

            RuleFor(model => model.AdvanceRequiredCurrency).Must((model, value) =>
            {
                if (!model.HasAdvanceRequired)
                {
                    return true;
                }

                return model.AdvanceRequiredCurrency != null;
            });
        }
    }
}

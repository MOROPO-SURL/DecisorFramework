using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseOrderPlannedProductSpentConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseOrderPlannedProductSpentConfigurationPageModel>
    {
        public PurchaseOrderPlannedProductSpentConfigurationValidator()
        {
            RuleFor(model => model.Product).NotNull();

            RuleFor(model => model.Amount).GreaterThan(0);

            RuleFor(model => model.UnitMeasurement).NotNull();

            RuleFor(model => model.Classification).Must((model, value) =>
            {
                if (model.AvailableClassifications.Length <= 0) return true;

                return value != null;
            });
        }
    }
}

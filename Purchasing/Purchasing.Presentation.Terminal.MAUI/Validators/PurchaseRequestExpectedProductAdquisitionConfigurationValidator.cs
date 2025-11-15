using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseRequestExpectedProductAdquisitionConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseRequestExpectedProductAdquisitionConfigurationPageModel>
    {
        public PurchaseRequestExpectedProductAdquisitionConfigurationValidator()
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

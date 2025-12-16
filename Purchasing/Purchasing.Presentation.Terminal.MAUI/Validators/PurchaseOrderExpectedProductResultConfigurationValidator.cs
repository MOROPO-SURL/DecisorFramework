using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseOrderExpectedProductResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseOrderExpectedProductResultConfigurationPageModel>
    {
        public PurchaseOrderExpectedProductResultConfigurationValidator()
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

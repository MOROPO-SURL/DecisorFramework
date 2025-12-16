using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalProviderBugetProductConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalProviderBudgetProductConfigurationPageModel>
    {
        public LegalProviderBugetProductConfigurationValidator()
        {
            RuleFor(model => model.Product).NotNull();

            RuleFor(model => model.UnitPrice).GreaterThan(0);

            RuleFor(model => model.Currency).NotNull();

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

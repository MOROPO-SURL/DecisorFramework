using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class LegalProviderBudgetConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalProviderBudgetConfigurationPageModel>
    {
        public LegalProviderBudgetConfigurationValidator()
        {
            RuleFor(model => model.Number).GreaterThan(0);

            RuleFor(model => model.Year).GreaterThan(0);

            RuleFor(model => model.Provider).NotNull();

            RuleFor(model => model.Commercial).NotNull();

            RuleFor(model => model.BudgetProducts).NotEmpty();
        }
    }
}

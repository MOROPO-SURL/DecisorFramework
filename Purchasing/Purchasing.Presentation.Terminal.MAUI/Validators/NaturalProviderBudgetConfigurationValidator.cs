using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalProviderBudgetConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel>
    {
        public NaturalProviderBudgetConfigurationValidator()
        {
            RuleFor(model => model.Number).GreaterThan(0);

            RuleFor(model => model.Year).GreaterThan(0);

            RuleFor(model => model.Provider).NotNull();

            RuleFor(model => model.Commercial).NotNull();

            RuleFor(model => model.ProductBridges).NotEmpty();
        }
    }
}

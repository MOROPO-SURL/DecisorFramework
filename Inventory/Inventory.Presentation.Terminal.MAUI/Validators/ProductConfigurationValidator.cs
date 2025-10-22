using FluentValidation;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Validators
{
    public class ProductConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProductConfigurationPageModel>
    {
        public ProductConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.DefaultUnitMeasurement).NotNull();
        }
    }
}

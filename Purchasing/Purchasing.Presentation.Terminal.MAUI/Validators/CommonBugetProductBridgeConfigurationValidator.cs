using FluentValidation;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class CommonBugetProductBridgeConfigurationValidator : AbstractValidator<Models.Page.Configuration.CommonBugetProductBridgeConfigurationPageModel>
    {
        public CommonBugetProductBridgeConfigurationValidator()
        {
            RuleFor(model => model.Product).NotNull();

            RuleFor(model => model.UnitPrice).GreaterThan(0);

            RuleFor(model => model.Currency).NotNull();

            RuleFor(model => model.Amount).GreaterThan(0);

            RuleFor(model => model.UnitMeasurement).NotNull();
        }
    }
}

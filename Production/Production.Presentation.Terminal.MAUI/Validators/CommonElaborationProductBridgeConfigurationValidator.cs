using FluentValidation;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public class CommonElaborationProductBridgeConfigurationValidator : AbstractValidator<Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel>
{
    public CommonElaborationProductBridgeConfigurationValidator()
    {
        RuleFor(model => model.Product).NotNull();

        RuleFor(model => model.Amount).GreaterThan(0);

        RuleFor(model => model.UnitMeasurement).NotNull();

        RuleFor(model => model.Classification).Must((model, value) =>
        {
            if (model.Product == null) return true;

            if (model.Product.Classifications == null || model.Product.Classifications.Length <= 0) return true;

            return value != null;
        });
    }
}

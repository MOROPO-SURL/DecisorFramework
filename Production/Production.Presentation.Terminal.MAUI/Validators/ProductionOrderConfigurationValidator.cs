using FluentValidation;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public class ProductionOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProductionOrderConfigurationPageModel>
{
    public ProductionOrderConfigurationValidator()
    {
        RuleFor(model => model.Elaboration).NotNull();

        RuleFor(model => model.Agreement).NotNull();

        RuleFor(model => model.Responsible).NotNull();

        RuleFor(model => model.Amount).GreaterThan(0);
    }
}

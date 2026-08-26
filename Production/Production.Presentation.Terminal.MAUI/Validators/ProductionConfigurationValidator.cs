using FluentValidation;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public class ProductionConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProductionConfigurationPageModel>
{
    public ProductionConfigurationValidator()
    {
        RuleFor(model => model.Order).NotNull().WithName("Orden");

        RuleFor(model => model.UnitMeasurement).NotNull().WithName("Unidad de medida");

        RuleFor(model => model.Amount).GreaterThan(0).WithName("Cantidad");

        RuleFor(model => model.At).LessThanOrEqualTo(System.DateTime.Now).WithName("Fecha");
    }
}
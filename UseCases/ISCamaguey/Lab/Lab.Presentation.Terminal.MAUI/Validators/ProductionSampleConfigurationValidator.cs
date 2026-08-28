using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class ProductionSampleConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProductionSampleConfigurationPageModel>
{
    public ProductionSampleConfigurationValidator()
    {
        RuleFor(model => model.Index).NotEmpty().GreaterThanOrEqualTo(1).WithName("Número");

        RuleFor(model => model.Year).NotNull().WithName("Año");

        RuleFor(model => model.SampleKind).NotNull().WithName("Tipo");

        RuleFor(model => model.Production).NotNull().WithName("Producción");

        RuleFor(model => model.UnitMeasurement).NotNull().WithName("Unidad de medida");

        RuleFor(model => model.Amount).NotEmpty().GreaterThan(0).WithName("Cantidad");
    }
}
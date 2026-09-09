using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class ServiceOrderSampleConfigurationValidator : AbstractValidator<Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel>
{
    public ServiceOrderSampleConfigurationValidator()
    {
        RuleFor(model => model.Index).NotEmpty().GreaterThanOrEqualTo(1).WithName("Número");

        RuleFor(model => model.Year).NotNull().WithName("Año");

        RuleFor(model => model.SampleKind).NotNull().WithName("Tipo");

        RuleFor(model => model.Order).NotNull().WithName("Órden de servicio");

        RuleFor(model => model.UnitMeasurement).NotNull().WithName("Unidad de medida");

        RuleFor(model => model.Amount).NotEmpty().GreaterThan(0).WithName("Cantidad");
    }
}
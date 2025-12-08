using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class ServiceOrderSampleConfigurationValidator : AbstractValidator<Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel>
{
    public ServiceOrderSampleConfigurationValidator()
    {
        RuleFor(model => model.Index).NotEmpty().GreaterThanOrEqualTo(1);

        RuleFor(model => model.Year).NotNull();

        RuleFor(model => model.SampleKind).NotNull();

        RuleFor(model => model.Order).NotNull();

        RuleFor(model => model.UnitMeasurement).NotNull();

        RuleFor(model => model.Amount).NotEmpty().GreaterThan(0);
    }
}
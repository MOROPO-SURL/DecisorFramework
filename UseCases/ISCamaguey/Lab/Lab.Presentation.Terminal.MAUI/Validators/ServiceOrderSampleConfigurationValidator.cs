using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class ServiceOrderSampleConfigurationValidator : AbstractValidator<Models.Page.Configuration.ServiceOrderSampleConfigurationPageModel>
{
    public ServiceOrderSampleConfigurationValidator()
    {
        RuleFor(model => model.Label).NotNull();

        RuleFor(model => model.SampleKind).NotNull();

        RuleFor(model => model.Order).NotNull();

        RuleFor(model => model.UnitMeasurement).NotNull();

        RuleFor(model => model.Amount).GreaterThan(0);
    }
}

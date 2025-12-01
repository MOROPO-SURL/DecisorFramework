using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class SampleReceptionLabelConfigurationValidator : AbstractValidator<Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel>
{
    public SampleReceptionLabelConfigurationValidator()
    {
        RuleFor(model => model.Reference).NotNull().NotEmpty();

        RuleFor(model => model.Priority).GreaterThanOrEqualTo(1);
    }
}

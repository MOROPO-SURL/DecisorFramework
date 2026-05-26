using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class InternalResearcherConfigurationValidator : AbstractValidator<Models.Page.Configuration.InternalResearcherConfigurationPageModel>
{
    public InternalResearcherConfigurationValidator()
    {
        RuleFor(model => model.Employee).NotNull();

        RuleFor(model => model.TimeAvailability).GreaterThan(0);
    }
}
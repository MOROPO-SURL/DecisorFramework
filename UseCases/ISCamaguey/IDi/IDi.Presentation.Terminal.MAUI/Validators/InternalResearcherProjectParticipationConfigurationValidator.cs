using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class InternalResearcherProjectParticipationConfigurationValidator : AbstractValidator<Models.Page.Configuration.InternalResearcherProjectParticipationConfigurationPageModel>
{
    public InternalResearcherProjectParticipationConfigurationValidator()
    {
        RuleFor(model => model.Researcher).NotNull();

        RuleFor(model => model.TimeAvailability).GreaterThan(0);
    }
}

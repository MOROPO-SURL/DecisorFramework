using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ExternalResearcherProjectParticipationConfigurationValidator : AbstractValidator<Models.Page.Configuration.ExternalResearcherProjectParticipationConfigurationPageModel>
{
    public ExternalResearcherProjectParticipationConfigurationValidator()
    {
        RuleFor(model => model.Researcher).NotNull();

        RuleFor(model => model.TimeAvailability).GreaterThan(0);
    }
}
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ProjectProposalConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProjectProposalConfigurationPageModel>
{
    public ProjectProposalConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(model => model.Description)
            .NotEmpty()
            .MaximumLength(5100);
    }
}

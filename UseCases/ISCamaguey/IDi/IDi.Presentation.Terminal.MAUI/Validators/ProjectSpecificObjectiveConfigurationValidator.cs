using FluentValidation;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public sealed class ProjectSpecificObjectiveConfigurationValidator : AbstractValidator<ProjectSpecificObjectiveConfigurationPageModel>
{
    public ProjectSpecificObjectiveConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(255)
            .WithName("Nombre");

        RuleFor(model => model.Description)
            .MaximumLength(2550)
            .WithName("Descripción");
    }
}
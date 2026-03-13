using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators;

public class AcademicAchievementConfigurationValidator : AbstractValidator<Models.Page.Configuration.AcademicAchievementConfigurationPageModel>
{
    public AcademicAchievementConfigurationValidator()
    {
        RuleFor(model => model.MainKnowledgeArea)
            .NotNull()
            .WithName("Área del conocimiento");

        RuleFor(model => model.Title)
            .MaximumLength(512)
            .WithName("Titulación");

        RuleFor(model => model.Institution)
            .MaximumLength(512)
            .WithName("Institución");
    }
}

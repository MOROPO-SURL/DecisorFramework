using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class WorkPositionConfigurationValidator : AbstractValidator<Models.Page.Configuration.WorkPositionConfigurationPageModel>
{
    public WorkPositionConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Categoría ocupacional");

        RuleFor(model => model.EducationLevel)
            .NotNull()
            .WithName("Nivel de escolaridad");
    }
}

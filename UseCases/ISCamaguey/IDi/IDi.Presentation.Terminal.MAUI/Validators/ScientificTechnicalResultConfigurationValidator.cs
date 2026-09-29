using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ScientificTechnicalResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel>
{
    public ScientificTechnicalResultConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512);

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");
    }
}
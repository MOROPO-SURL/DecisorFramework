using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class AwardResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.AwardResultConfigurationPageModel>
{
    public AwardResultConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512);

        RuleFor(model => model.AwardKind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.Receptor)
            .NotNull()
            .WithName("Recibe");
    }
}
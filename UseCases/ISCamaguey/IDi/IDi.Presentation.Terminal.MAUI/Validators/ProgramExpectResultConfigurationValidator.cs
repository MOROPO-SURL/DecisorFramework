using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ProgramExpectResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProgramExpectResultConfigurationPageModel>
{
    public ProgramExpectResultConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Título");

        RuleFor(model => model.Index)
            .GreaterThanOrEqualTo(1)
            .WithName("Número");

        RuleFor(model => model.Description)
            .MaximumLength(2048)
            .WithName("Descripción");
    }
}

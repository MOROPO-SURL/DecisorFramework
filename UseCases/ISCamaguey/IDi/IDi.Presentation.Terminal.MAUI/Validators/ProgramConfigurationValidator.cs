using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ProgramConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProgramConfigurationPageModel>
{
    public ProgramConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(320)
            .WithName("Nombre");

        RuleFor(model => model.Alias)
            .MaximumLength(60)
            .WithName("Alias");

        RuleFor(model => model.Code)
            .NotEmpty()
            .MaximumLength(60)
            .WithName("Código");

        RuleFor(model => model.Kind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.Chief)
            .NotNull()
            .WithName("Jefe");

        RuleFor(model => model.Manager)
            .NotNull()
            .WithName("Organización Gestora");

        RuleFor(model => model.ExpectResults)
            .NotEmpty()
            .WithName("Resultados / Prioridades");
    }
}

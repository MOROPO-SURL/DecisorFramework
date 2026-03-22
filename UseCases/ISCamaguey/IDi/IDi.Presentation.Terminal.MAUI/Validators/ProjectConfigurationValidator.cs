using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ProjectConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProjectConfigurationPageModel>
{
    public ProjectConfigurationValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .MaximumLength(500)
            .WithName("Nombre");

        RuleFor(model => model.Alias)
            .MaximumLength(60)
            .WithName("Alias");

        RuleFor(model => model.Code)
            .NotEmpty()
            .MaximumLength(60)
            .WithName("Código");

        RuleFor(model => model.Summary)
            .NotEmpty()
            .MaximumLength(5000)
            .WithName("Resumen");

        RuleFor(model => model.Problem)
            .NotEmpty()
            .MaximumLength(10000)
            .WithName("Problema");

        RuleFor(model => model.Context)
            .NotEmpty()
            .MaximumLength(500000)
            .WithName("Contexto");

        RuleFor(model => model.Beneficiary)
            .NotEmpty()
            .MaximumLength(5000)
            .WithName("Beneficiario");

        RuleFor(model => model.MainObjetive)
            .NotEmpty()
            .MaximumLength(1000)
            .WithName("Objetivo general");

        RuleFor(model => model.Category)
            .NotNull()
            .WithName("Categoría");

        RuleFor(model => model.Chief)
            .NotNull()
            .WithName("Jefe");

        RuleFor(model => model.EndAt)
            .GreaterThan(model => model.StartAt)
            .WithName("Fecha de cierre");
    }
}

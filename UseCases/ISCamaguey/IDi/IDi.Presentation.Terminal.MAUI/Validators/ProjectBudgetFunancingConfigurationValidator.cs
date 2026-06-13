using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public sealed class ProjectBudgetFunancingConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProjectBudgetFunancingConfigurationPageModel>
{
    public ProjectBudgetFunancingConfigurationValidator()
    {
        RuleFor(model => model.Financier)
            .NotNull()
            .WithName("Financista");

        RuleFor(model => model.Currency)
            .NotNull()
            .WithName("Moneda");

        RuleFor(model => model.Amount)
            .GreaterThan(0)
            .WithName("Monto");
    }
}

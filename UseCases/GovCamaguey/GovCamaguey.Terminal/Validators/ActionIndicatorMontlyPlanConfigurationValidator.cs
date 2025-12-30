using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators;

public class ActionIndicatorMontlyPlanConfigurationValidator : AbstractValidator<Models.Page.Configuration.ActionIndicatorMontlyPlanConfigurationPageModel>
{
    public ActionIndicatorMontlyPlanConfigurationValidator()
    {
        RuleFor(model => model.YearMonth)
            .NotNull()
            .WithName("Mes / Año");

        RuleFor(model => model.Amount)
            .NotNull()
            .GreaterThan(0)
            .WithName("Meta");
    }
}

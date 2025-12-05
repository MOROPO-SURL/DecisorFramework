using FluentValidation;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public class ElaborationStepConfigurationValidator : AbstractValidator<Models.Page.Configuration.ElaborationStepConfigurationPageModel>
{
    public ElaborationStepConfigurationValidator()
    {
        RuleFor(model => model.Name).NotNull().NotEmpty();

        RuleFor(model => model.Description).NotNull().NotEmpty();

        RuleFor(model => model.WorkPositions).NotEmpty();

        RuleFor(model => model.MinDecrease).GreaterThanOrEqualTo(0);

        RuleFor(model => model.MaxDecrease).GreaterThanOrEqualTo(model => model.MinDecrease);
    }
}

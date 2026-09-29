using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class AwardKindConfigurationValidator : AbstractValidator<Models.Page.Configuration.AwardKindConfigurationPageModel>
{
    public AwardKindConfigurationValidator()
    {
        RuleFor(model => model.Name).NotNull().NotEmpty();
    }
}
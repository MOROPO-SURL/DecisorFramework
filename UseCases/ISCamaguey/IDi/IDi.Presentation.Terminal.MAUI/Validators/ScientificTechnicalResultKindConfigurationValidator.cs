using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ScientificTechnicalResultKindConfigurationValidator : AbstractValidator<Models.Page.Configuration.ScientificTechnicalResultKindConfigurationPageModel>
{
    public ScientificTechnicalResultKindConfigurationValidator()
    {
        RuleFor(model => model.Name).NotNull().NotEmpty();
    }
}
using FluentValidation;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Validators;

public class AgreementConfigurationValidator : AbstractValidator<Models.Page.Configuration.AgreementConfigurationPageModel>
{
    public AgreementConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .WithName("Título");
    }
}

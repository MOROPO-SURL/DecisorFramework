using FluentValidation;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Validators;

public class MeetingConfigurationValidator : AbstractValidator<Models.Page.Configuration.MeetingConfigurationPageModel>
{
    public MeetingConfigurationValidator()
    {
        RuleFor(model => model.Group)
            .NotNull()
            .WithName("Grupo Decisor");

        RuleFor(model => model.Author)
            .NotNull()
            .WithName("Secreatrio(a)");

        RuleFor(model => model.AtDate)
            .LessThanOrEqualTo(System.DateTime.Now)
            .WithName("Fecha");
    }
}

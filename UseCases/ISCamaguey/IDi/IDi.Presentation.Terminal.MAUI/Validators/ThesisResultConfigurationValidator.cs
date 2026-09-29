using FluentValidation;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class ThesisResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.ThesisResultConfigurationPageModel>
{
    public ThesisResultConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512);

        RuleFor(model => model.ThesisKind)
            .NotNull()
            .WithName("Tipo");

        RuleFor(model => model.Document)
            .NotNull()
            .WithName("Documento");

        RuleFor(model => model.InternalResearchers)
            .Must((model, value) => model.InternalResearchers.Any() || model.ExternalResearchers.Any())
            .WithMessage("Al menos debe especificarse un investigador interno o externo.");

        RuleFor(model => model.ExternalResearchers)
            .Must((model, value) => model.InternalResearchers.Any() || model.ExternalResearchers.Any())
            .WithMessage("Al menos debe especificarse un investigador interno o externo.");
    }
}

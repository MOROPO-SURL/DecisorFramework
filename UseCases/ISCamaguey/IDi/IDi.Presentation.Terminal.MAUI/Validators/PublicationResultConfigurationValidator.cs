using FluentValidation;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators;

public class PublicationResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.PublicationResultConfigurationPageModel>
{
    public PublicationResultConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Título");

        RuleFor(model => model.Description)
            .NotEmpty()
            .MaximumLength(5100)
            .WithName("Sumario");

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

using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class OcupationCandidateConfigurationValidator : AbstractValidator<Models.Page.Configuration.OcupationCandidateConfigurationPageModel>
{
    public OcupationCandidateConfigurationValidator()
    {
        RuleFor(model => model.Postulation)
            .NotNull()
            .WithName("Postulación");

        RuleFor(model => model.Responsible)
            .NotNull()
            .WithName("Aprueba");
    }
}

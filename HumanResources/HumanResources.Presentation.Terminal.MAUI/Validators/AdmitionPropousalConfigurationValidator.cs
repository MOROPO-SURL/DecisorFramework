using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class AdmitionPropousalConfigurationValidator : AbstractValidator<Models.Page.Configuration.AdmitionPropousalConfigurationPageModel>
{
    public AdmitionPropousalConfigurationValidator()
    {
        RuleFor(model => model.Candidate)
            .NotNull()
            .WithName("Candidato");

        RuleFor(model => model.Agreement)
            .NotNull()
            .WithName("Acuerdo");
    }
}

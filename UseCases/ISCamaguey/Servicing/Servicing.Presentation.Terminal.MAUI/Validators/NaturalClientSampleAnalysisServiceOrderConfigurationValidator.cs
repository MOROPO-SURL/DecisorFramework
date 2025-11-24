using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators;

public class NaturalClientSampleAnalysisServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
    public NaturalClientSampleAnalysisServiceOrderConfigurationValidator()
    {
        RuleFor(model => model.Contract).NotNull();

        RuleFor(model => model.Service).NotNull();

        RuleFor(model => model.Description).NotNull().NotEmpty();
    }
}
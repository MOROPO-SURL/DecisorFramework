using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators;

public class LegalClientSampleAnalysisServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
    public LegalClientSampleAnalysisServiceOrderConfigurationValidator()
    {
        RuleFor(model => model.Contract).NotNull();

        RuleFor(model => model.Service).NotNull();

        RuleFor(model => model.Description).NotNull().NotEmpty();
    }
}

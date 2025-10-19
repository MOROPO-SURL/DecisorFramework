using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class SampleAnalysisServiceStepConfigurationValidator : AbstractValidator<Models.Page.Configuration.SampleAnalysisServiceStepConfigurationPageModel>
    {
        public SampleAnalysisServiceStepConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

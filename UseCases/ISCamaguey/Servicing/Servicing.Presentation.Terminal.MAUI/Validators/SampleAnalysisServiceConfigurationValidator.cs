using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class SampleAnalysisServiceConfigurationValidator : AbstractValidator<Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel>
    {
        public SampleAnalysisServiceConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();

            RuleFor(model => model.SampleKind).NotNull();
        }
    }
}

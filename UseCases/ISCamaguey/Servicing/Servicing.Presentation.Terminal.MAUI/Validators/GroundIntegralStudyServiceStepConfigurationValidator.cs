using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class GroundIntegralStudyServiceStepConfigurationValidator : AbstractValidator<Models.Page.Configuration.GroundIntegralStudyServiceStepConfigurationPageModel>
    {
        public GroundIntegralStudyServiceStepConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

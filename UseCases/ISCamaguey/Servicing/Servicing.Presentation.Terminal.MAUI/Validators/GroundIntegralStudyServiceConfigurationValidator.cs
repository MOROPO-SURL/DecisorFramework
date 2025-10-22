using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class GroundIntegralStudyServiceConfigurationValidator : AbstractValidator<Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel>
    {
        public GroundIntegralStudyServiceConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();

            RuleFor(model => model.Responsible).NotNull();
        }
    }
}


using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientGroundIntegralStudyServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
    {
        public LegalClientGroundIntegralStudyServiceOrderConfigurationValidator()
        {
            RuleFor(model => model.Contract).NotNull();

            RuleFor(model => model.Service).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

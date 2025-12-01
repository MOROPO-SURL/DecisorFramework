
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientGroundIntegralStudyServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
    {
        public NaturalClientGroundIntegralStudyServiceOrderConfigurationValidator()
        {
            RuleFor(model => model.Contract).NotNull();

            RuleFor(model => model.Service).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}


using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientTrainingServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientTrainingServiceOrderConfigurationPageModel>
    {
        public LegalClientTrainingServiceOrderConfigurationValidator()
        {
            RuleFor(model => model.Contract).NotNull();

            RuleFor(model => model.Service).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

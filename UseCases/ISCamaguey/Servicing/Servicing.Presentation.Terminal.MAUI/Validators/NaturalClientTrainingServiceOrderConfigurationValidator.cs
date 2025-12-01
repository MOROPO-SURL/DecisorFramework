
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class NaturalClientTrainingServiceOrderConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientTrainingServiceOrderConfigurationPageModel>
    {
        public NaturalClientTrainingServiceOrderConfigurationValidator()
        {
            RuleFor(model => model.Contract).NotNull();

            RuleFor(model => model.Service).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

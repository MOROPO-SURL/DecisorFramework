using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class TrainingServiceConfigurationValidator : AbstractValidator<Models.Page.Configuration.TrainingServiceConfigurationPageModel>
    {
        public TrainingServiceConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

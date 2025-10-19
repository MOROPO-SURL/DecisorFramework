using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators
{
    public class TrainingServiceStepConfigurationValidator : AbstractValidator<Models.Page.Configuration.TrainingServiceStepConfigurationPageModel>
    {
        public TrainingServiceStepConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators
{
    public class WorkingGroupConfigurationValidator : AbstractValidator<Models.Page.Configuration.WorkingGroupConfigurationPageModel>
    {
        public WorkingGroupConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Chief).NotNull();

            RuleFor(model => model.QualitySpecialist).NotNull();
        }
    }
}

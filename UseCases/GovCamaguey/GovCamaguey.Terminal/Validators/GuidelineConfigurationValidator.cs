using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class GuidelineConfigurationValidator : AbstractValidator<Models.Page.Configuration.GuidelineConfigurationPageModel>
    {
        public GuidelineConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Index)
                .NotNull();
        }
    }
}

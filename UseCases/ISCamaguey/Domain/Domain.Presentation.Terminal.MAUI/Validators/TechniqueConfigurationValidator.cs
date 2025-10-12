using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class TechniqueConfigurationValidator : AbstractValidator<Models.Page.Configuration.TechniqueConfigurationPageModel>
    {
        public TechniqueConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

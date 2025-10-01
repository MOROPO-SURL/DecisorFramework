using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class ResearchAreaConfigurationValidator : AbstractValidator<Models.Page.Configuration.ResearchAreaConfigurationPageModel>
    {
        public ResearchAreaConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

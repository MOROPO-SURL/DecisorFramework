using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class BrandConfigurationValidator : AbstractValidator<Models.Page.Configuration.BrandConfigurationPageModel>
    {
        public BrandConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

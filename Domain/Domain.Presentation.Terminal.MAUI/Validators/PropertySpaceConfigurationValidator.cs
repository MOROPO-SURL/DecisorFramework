using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class PropertySpaceConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertySpaceConfigurationPageModel>
    {
        public PropertySpaceConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Area).NotNull().GreaterThan(0);
        }
    }
}

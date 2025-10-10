using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class PropertyConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyConfigurationPageModel>
    {
        public PropertyConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Structure).NotNull();

            RuleFor(model => model.Kind).NotNull();

            RuleFor(model => model.Reference).NotNull().NotEmpty();

            RuleFor(model => model.PostalContact).NotNull();

            RuleFor(model => model.Spaces).NotEmpty();
        }
    }
}

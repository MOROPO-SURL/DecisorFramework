using FluentValidation;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Validators
{
    public class ClassificationConfigurationValidator : AbstractValidator<Models.Page.Configuration.ClassificationConfigurationPageModel>
    {
        public ClassificationConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

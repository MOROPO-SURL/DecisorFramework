using FluentValidation;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Validators
{
    public class FamilyConfigurationValidator : AbstractValidator<Models.Page.Configuration.FamilyConfigurationPageModel>
    {
        public FamilyConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

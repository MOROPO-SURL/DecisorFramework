using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class OrganizationContactConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationContactConfigurationPageModel>
    {
        public OrganizationContactConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Representative).NotNull();

            RuleFor(model => model.BusinessKind).NotNull();
        }
    }
}

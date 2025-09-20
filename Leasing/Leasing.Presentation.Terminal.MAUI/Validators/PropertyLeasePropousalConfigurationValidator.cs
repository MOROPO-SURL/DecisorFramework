using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class PropertyLeasePropousalConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
    {
        public PropertyLeasePropousalConfigurationValidator()
        {
            RuleFor(model => model.Property).NotNull();

            RuleFor(model => model.Agreement).NotNull();

            RuleFor(model => model.Author).NotNull();

            RuleFor(model => model.Description).NotNull().NotEmpty();

            RuleFor(model => model.SpacePropousals).NotEmpty();
        }
    }
}

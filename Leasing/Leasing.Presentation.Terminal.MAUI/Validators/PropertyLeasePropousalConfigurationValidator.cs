using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public class PropertyLeasePropousalConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
{
    public PropertyLeasePropousalConfigurationValidator()
    {
        RuleFor(model => model.Property).NotNull();

        RuleFor(model => model.Agreement).NotNull();

        RuleFor(model => model.Author).NotNull();

        RuleFor(model => model.Description).NotEmpty();

        RuleFor(model => model.SpacePropousals).NotEmpty();

        RuleFor(model => model.BaselineAmount).NotEmpty().GreaterThan(0);

        RuleFor(model => model.BaselineCurrency).NotNull();
    }
}

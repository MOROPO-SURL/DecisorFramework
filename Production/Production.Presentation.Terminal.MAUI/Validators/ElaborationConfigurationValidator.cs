using FluentValidation;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public class ElaborationConfigurationValidator : AbstractValidator<Models.Page.Configuration.ElaborationConfigurationPageModel>
{
    public ElaborationConfigurationValidator()
    {
        RuleFor(model => model.Product).NotNull();

        RuleFor(model => model.Classification).Must((model, value) =>
        {
            if (model.Product == null) return true;

            if (model.Product.Classifications == null || model.Product.Classifications.Length <= 0) return true;

            return value != null;
        });

        RuleFor(model => model.MinPerformanceCoefficient).GreaterThanOrEqualTo(0);

        RuleFor(model => model.MaxPerformanceCoefficient).GreaterThanOrEqualTo(model => model.MinPerformanceCoefficient);

        RuleFor(model => model.Description).NotNull().NotEmpty();

        RuleFor(model => model.Steps).NotEmpty();
    }
}

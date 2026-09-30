using FluentValidation;
using MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.Validators;

public sealed class ProductionQualityCheckConfigurationValidator : AbstractValidator<ProductionQualityCheckConfigurationPageModel>
{
    public ProductionQualityCheckConfigurationValidator()
    {
        RuleFor(model => model.Production).NotNull().WithName("Producción");

        RuleFor(model => model.Author).NotNull().WithName("Especialista");

        RuleFor(model => model.Description).NotEmpty().WithName("Conclusiones");
    }
}

using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Validators;

public class NaturalClientGroundIntegralStudyServiceExecutionConfigurationValidator : AbstractValidator<Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceExecutionConfigurationPageModel>
{
    public NaturalClientGroundIntegralStudyServiceExecutionConfigurationValidator()
    {
        RuleFor(model => model.Order).NotNull().WithName("Orden");

        RuleFor(model => model.Author).NotNull().WithName("Especialista");

        RuleFor(model => model.Document).NotNull().WithName("Informe");

        RuleFor(model => model.Description).NotEmpty().WithName("Descripción");
    }
}

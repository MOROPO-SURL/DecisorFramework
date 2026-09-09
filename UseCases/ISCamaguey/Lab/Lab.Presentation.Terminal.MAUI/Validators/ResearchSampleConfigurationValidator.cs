using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Validators;

public class ResearchSampleConfigurationValidator : AbstractValidator<Models.Page.Configuration.ResearchSampleConfigurationPageModel>
{
    public ResearchSampleConfigurationValidator()
    {
        RuleFor(model => model.Index).NotEmpty().GreaterThanOrEqualTo(1);

        RuleFor(model => model.Year).NotNull();

        RuleFor(model => model.SampleKind).NotNull().WithName("Tipo");

        RuleFor(model => model.Project).NotNull().WithName("Proyecto");

        RuleFor(model => model.ResearcherContact).NotNull().WithName("Investigador");

        RuleFor(model => model.UnitMeasurement).NotNull().WithName("Unidade de medida");

        RuleFor(model => model.Amount).NotEmpty().GreaterThan(0).WithName("Cantidad");
    }
}
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.Validators;

public class RecomendationReportConfigurationValidator : AbstractValidator<Models.Page.Configuration.RecomendationReportConfigurationPageModel>
{
    public RecomendationReportConfigurationValidator()
    {
        RuleFor(model => model.Title)
            .NotEmpty()
            .MaximumLength(512)
            .WithName("Título");

        RuleFor(model => model.Document)
            .NotNull()
            .WithName("Documento");

        RuleFor(model => model.Authors)
            .NotEmpty()
            .WithName("Autores");
    }
}

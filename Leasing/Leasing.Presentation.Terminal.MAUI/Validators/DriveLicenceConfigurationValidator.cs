using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators;

public class DriveLicenceConfigurationValidator : AbstractValidator<Models.Page.Configuration.DriveLicenceConfigurationPageModel>
{
    public DriveLicenceConfigurationValidator()
    {
        RuleFor(model => model.Contact)
            .NotNull();

        RuleFor(model => model.Code)
            .NotEmpty()
            .MaximumLength(100)
            .WithName("Número");

        RuleFor(model => model.Reference)
            .NotEmpty()
            .MaximumLength(100)
            .WithName("Serie");

        RuleFor(model => model.ExpireAtYear)
            .GreaterThan(model =>  model.ReleasedAtYear)
            .WithName("Año de vencimiento");
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class StaffConfigurationValidator : AbstractValidator<Models.Page.Configuration.StaffConfigurationPageModel>
{
    public StaffConfigurationValidator()
    {
        RuleFor(model => model.Structure)
            .NotNull()
            .WithName("Entidad Administrativa");

        RuleFor(model => model.MainWorkforce)
            .NotNull()
            .WithName("Principal Estructura de Plantilla");

        RuleFor(model => model.WorkingDayCount)
            .InclusiveBetween(1, 28)
            .WithName("Días laborables");
    }
}

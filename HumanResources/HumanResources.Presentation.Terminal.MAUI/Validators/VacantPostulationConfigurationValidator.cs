using FluentValidation;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Validators;

public class VacantPostulationConfigurationValidator : AbstractValidator<Models.Page.Configuration.VacantPostulationConfigurationPageModel>
{
    public VacantPostulationConfigurationValidator()
    {
        RuleFor(model => model.Vacant)
            .NotNull()
            .WithName("Puesto");

        RuleFor(model => model.Contact)
            .NotNull()
            .WithName("Contacto");

        RuleFor(model => model.PersonalIdentificationNumber)
            .NotEmpty()
            .Matches("^[0-9]{11}$")
            .WithName("No. de Identidad");

        RuleFor(model => model.OfficialPostalContactItem)
            .NotNull()
            .WithName("Dirección postal oficial");

        RuleFor(model => model.UltimateEducationInstitution)
            .MaximumLength(256)
            .WithName("Centro de estudios");

        RuleFor(model => model.TitulationTitle)
            .Must((model, value) =>
            {
                return model.EducationLevel switch
                {
                    Domain.Persistence.Enumerations.EducationLevel.Bachelor or Domain.Persistence.Enumerations.EducationLevel.Technical => !string.IsNullOrEmpty(value),
                    _ => true,
                };
            })
            .MaximumLength(512)
            .WithName("Titulación");

        RuleFor(model => model.MaleParentName)
            .MaximumLength(200)
            .WithName("Nombre del Padre");

        RuleFor(model => model.FemaleParentName)
            .MaximumLength(200)
            .WithName("Nombre de la Madre");

        RuleFor(model => model.Alignment)
            .MaximumLength(256)
            .WithName("Integración revolucionaria");

        RuleFor(model => model.ResponsabilityCommitment)
            .NotEmpty()
            .MaximumLength(1024)
            .WithName("Actividades que puede desempeñar");
    }
}

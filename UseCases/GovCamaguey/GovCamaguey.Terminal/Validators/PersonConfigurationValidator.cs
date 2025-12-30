using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class PersonConfigurationValidator : AbstractValidator<Models.Page.Configuration.PersonConfigurationPageModel>
    {
        public PersonConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithName("Nombre");

            RuleFor(model => model.Sex)
                .NotNull()
                .WithName("Sexo");
        }
    }
}

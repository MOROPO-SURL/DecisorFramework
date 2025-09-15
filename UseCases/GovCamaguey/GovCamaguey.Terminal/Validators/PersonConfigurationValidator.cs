using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class PersonConfigurationValidator : AbstractValidator<Models.Page.Configuration.PersonConfigurationPageModel>
    {
        public PersonConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Sex)
                .NotNull();
        }
    }
}

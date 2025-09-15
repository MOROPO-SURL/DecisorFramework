using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class ProyectionConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProyectionConfigurationPageModel>
    {
        public ProyectionConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Index)
                .NotNull()
                .GreaterThan(0);

            RuleFor(model => model.ResponsabilityOrganizations)
                .NotEmpty();
        }
    }
}

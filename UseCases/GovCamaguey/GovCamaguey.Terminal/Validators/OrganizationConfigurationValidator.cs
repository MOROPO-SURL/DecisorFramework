using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class OrganizationConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationConfigurationPageModel>
    {
        public OrganizationConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotNull();
        }
    }
}

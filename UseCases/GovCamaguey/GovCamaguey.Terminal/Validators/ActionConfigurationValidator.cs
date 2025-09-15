using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class ActionConfigurationValidator : AbstractValidator<Models.Page.Configuration.ActionConfigurationPageModel>
    {
        public ActionConfigurationValidator()
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

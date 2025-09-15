using FluentValidation;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Validators
{
    public class ObjectiveConfigurationValidator : AbstractValidator<Models.Page.Configuration.ObjectiveConfigurationPageModel>
    {
        public ObjectiveConfigurationValidator()
        {
            RuleFor(model => model.Responsible)
                .NotNull();

            RuleFor(model => model.Name)
                .NotNull();

            RuleFor(model => model.Index)
                .NotNull()
                .GreaterThan(0);
        }
    }
}

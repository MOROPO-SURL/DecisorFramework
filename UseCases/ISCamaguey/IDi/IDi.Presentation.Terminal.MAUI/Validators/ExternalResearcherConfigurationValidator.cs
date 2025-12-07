using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class ExternalResearcherConfigurationValidator : AbstractValidator<Models.Page.Configuration.ExternalResearcherConfigurationPageModel>
    {
        public ExternalResearcherConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();

            RuleFor(model => model.ParticipatingOrganization).NotNull();

            RuleFor(model => model.TimeAvailability).GreaterThan(0);

            RuleFor(model => model.Salary).GreaterThan(0);
        }
    }
}

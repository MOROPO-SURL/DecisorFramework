using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class ParticipatingOrganizationConfigurationValidator : AbstractValidator<Models.Page.Configuration.ParticipatingOrganizationConfigurationPageModel>
    {
        public ParticipatingOrganizationConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();
        }
    }
}

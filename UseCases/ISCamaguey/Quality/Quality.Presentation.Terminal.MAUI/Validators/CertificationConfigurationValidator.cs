
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Validators
{
    public class CertificationConfigurationValidator : AbstractValidator<Models.Page.Configuration.CertificationConfigurationPageModel>
    {
        public CertificationConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

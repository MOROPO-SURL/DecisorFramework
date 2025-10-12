
using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Validators
{
    public class IsoStandardConfigurationValidator: AbstractValidator<Models.Page.Configuration.IsoStandardConfigurationPageModel>
    {
        public IsoStandardConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

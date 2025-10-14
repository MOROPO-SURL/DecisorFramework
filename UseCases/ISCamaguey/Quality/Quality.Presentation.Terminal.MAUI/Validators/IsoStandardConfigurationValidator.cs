using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Validators
{
    public class IsoStandardConfigurationValidator: AbstractValidator<Models.Page.Configuration.IsoStandardConfigurationPageModel>
    {
        public IsoStandardConfigurationValidator()
        {
            RuleFor(model => model.Index).GreaterThan(0);

            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Validators
{
    public class CubanStandardConfigurationValidator: AbstractValidator<Models.Page.Configuration.CubanStandardConfigurationPageModel>
    {
        public CubanStandardConfigurationValidator()
        {
            RuleFor(model => model.Index).GreaterThan(0);

            RuleFor(model => model.Name).NotNull().NotEmpty();
        }
    }
}

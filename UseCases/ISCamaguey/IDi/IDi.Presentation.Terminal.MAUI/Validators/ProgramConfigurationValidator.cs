using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class ProgramConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProgramConfigurationPageModel>
    {
        public ProgramConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.Code).NotNull().NotEmpty();

            RuleFor(model => model.Chief).NotNull();

            RuleFor(model => model.Manager).NotNull();
        }
    }
}

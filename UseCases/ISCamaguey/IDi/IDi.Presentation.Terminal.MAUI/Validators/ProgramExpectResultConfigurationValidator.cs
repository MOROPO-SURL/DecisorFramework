using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class ProgramExpectResultConfigurationValidator : AbstractValidator<Models.Page.Configuration.ProgramExpectResultConfigurationPageModel>
    {
        public ProgramExpectResultConfigurationValidator()
        {
            RuleFor(model => model.Title).NotNull().NotEmpty();

            RuleFor(model => model.Index).GreaterThan(1);

            RuleFor(model => model.Description).NotNull().NotEmpty();
        }
    }
}

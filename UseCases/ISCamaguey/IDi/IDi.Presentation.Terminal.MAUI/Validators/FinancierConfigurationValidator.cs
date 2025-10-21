using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class FinancierConfigurationValidator : AbstractValidator<Models.Page.Configuration.FinancierConfigurationPageModel>
    {
        public FinancierConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();
        }
    }
}

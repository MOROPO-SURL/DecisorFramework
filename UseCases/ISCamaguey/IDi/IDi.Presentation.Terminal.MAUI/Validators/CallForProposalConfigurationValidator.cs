using FluentValidation;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Validators
{
    public class CallForProposalConfigurationValidator : AbstractValidator<Models.Page.Configuration.CallForProposalConfigurationPageModel>
    {
        public CallForProposalConfigurationValidator()
        {
            RuleFor(model => model.Title).NotNull().NotEmpty();

            RuleFor(model => model.Description).NotNull().NotEmpty();

            RuleFor(model => model.Financier).NotNull();

            RuleFor(model => model.EndAt).GreaterThan(entity => entity.StartAt);
        }
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Validators
{
    public class CostCenterConfigurationValidator : AbstractValidator<Models.Page.Configuration.CostCenterConfigurationPageModel>
    {
        public CostCenterConfigurationValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty();

            RuleFor(model => model.DefaultBankAccount).NotNull();

            RuleFor(model => model.Structure).NotNull();
        }
    }
}

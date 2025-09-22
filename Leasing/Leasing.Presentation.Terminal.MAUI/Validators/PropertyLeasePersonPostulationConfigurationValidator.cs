using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class PropertyLeasePersonPostulationConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyLeasePersonPostulationConfigurationPageModel>
    {
        public PropertyLeasePersonPostulationConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();

            RuleFor(model => model.TaxIdentificationNumber)
                .NotNull()
                .Matches("^[0-9]{11}$");

            RuleFor(model => model.BusinessKind).NotNull();

            RuleFor(model => model.MainPostalContactItem).NotNull();

            RuleFor(model => model.Argument).NotNull();

            RuleFor(model => model.BankAccount).NotNull();

            RuleFor(model => model.Spaces).NotEmpty();
        }
    }
}

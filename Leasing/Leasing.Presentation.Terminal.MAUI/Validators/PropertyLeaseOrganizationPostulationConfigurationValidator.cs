using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class PropertyLeaseOrganizationPostulationConfigurationValidator : AbstractValidator<Models.Page.Configuration.PropertyLeaseOrganizationPostulationConfigurationPageModel>
    {
        public PropertyLeaseOrganizationPostulationConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();

            RuleFor(model => model.TaxIdentificationNumber)
                .NotNull()
                .Matches("^[0-9]+$");

            RuleFor(model => model.MainPostalContactItem).NotNull();

            RuleFor(model => model.Argument).NotNull();
        }
    }
}

using FluentValidation;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Validators
{
    public class VehicleLeaseOrganizationPostulationConfigurationValidator : AbstractValidator<Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel>
    {
        public VehicleLeaseOrganizationPostulationConfigurationValidator()
        {
            RuleFor(model => model.Contact).NotNull();

            RuleFor(model => model.TaxIdentificationNumber)
                .NotNull()
                .Matches("^[0-9]+$");

            RuleFor(model => model.MainPostalContactItem).NotNull();

            RuleFor(model => model.Argument).NotNull();

            RuleFor(model => model.BankAccount).NotNull();
        }
    }
}

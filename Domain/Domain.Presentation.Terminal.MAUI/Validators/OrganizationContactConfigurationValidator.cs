using FluentValidation;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Validators
{
    public class OrganizationContactConfigurationValidator : AbstractValidator<Models.Page.Configuration.OrganizationContactConfigurationPageModel>
    {
        public OrganizationContactConfigurationValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty()
                .WithName("Nombre");

            RuleFor(model => model.Representative)
                .NotEmpty()
                .WithName("Representante");

            RuleFor(model => model.BusinessKind)
                .NotNull()
                .WithName("Tipo");

            RuleFor(model => model.TaxIdentificationNumber)
                .Matches("^[0-9]+$")
                .WithName("NIT");
        }
    }
}

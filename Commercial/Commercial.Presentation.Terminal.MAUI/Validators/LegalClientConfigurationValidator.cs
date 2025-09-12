using FluentValidation;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Validators
{
    public class LegalClientConfigurationValidator : AbstractValidator<Models.Page.Configuration.LegalClientConfigurationPageModel>
    {
        public static string ContactProperty => nameof(Models.Page.Configuration.LegalClientConfigurationPageModel.Contact);
        public static string TaxIdentificationNumberProperty => nameof(Models.Page.Configuration.LegalClientConfigurationPageModel.TaxIdentificationNumber);

        public LegalClientConfigurationValidator()
        {
            RuleFor(model => model.Contact)
                .NotNull();

            RuleFor(model => model.TaxIdentificationNumber)
                .Matches("^[0-9]+$");
        }
    }
}

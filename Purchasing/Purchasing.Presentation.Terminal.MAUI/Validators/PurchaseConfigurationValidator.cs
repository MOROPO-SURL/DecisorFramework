using FluentValidation;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Validators
{
    public class PurchaseConfigurationValidator : AbstractValidator<Models.Page.Configuration.PurchaseConfigurationPageModel>
    {
        public PurchaseConfigurationValidator()
        {
            RuleFor(model => model.Purchaser).NotNull();

            RuleFor(model => model.Order).NotNull();

            RuleFor(model => model.LegalProviderProductBridges).Must((model, value) =>
            {
                if (model.NaturalProviderProductBridges.Any()) return true;

                return value.Any();
            });

            RuleFor(model => model.NaturalProviderProductBridges).Must((model, value) =>
            {
                if (model.LegalProviderProductBridges.Any()) return true;

                return value.Any();
            });
        }
    }
}

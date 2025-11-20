namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalProviderBudgetProductConfigurationPageModel : Contract.AbstractProviderBugetProductConfigurationPageModel<Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel, Persistence.Entities.LegalProviderBudgetProduct>
    {
        public static string ProductValidableProperty => nameof(Product);
        public static string UnitPriceValidableProperty => nameof(UnitPrice);
        public static string CurrencyValidableProperty => nameof(Currency);
        public static string AmountValidableProperty => nameof(Amount);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
        public static string ClassificationValidableProperty => nameof(Classification);

        public LegalProviderBudgetProductConfigurationPageModel(Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel model) : base(model)
        {
        }
    }
}

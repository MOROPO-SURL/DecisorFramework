using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ProjectBudgetFunancingConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ProjectBudgetFunancingDisplayModel>
{
    public static string FinancierValidableProperty => nameof(Financier);
    public static string CurrencyValidableProperty => nameof(Currency);
    public static string AmountValidableProperty => nameof(Amount);

    private FinancierDisplayModel financier;
    private CurrencyDisplayModel currency;
    private float amount;

    public ProjectBudgetFunancingConfigurationPageModel(ProjectBudgetFunancingDisplayModel model) : base(model)
    {
        financier = model?.Financier;
        currency = model?.Currency;
        amount = model?.Amount ?? default;
    }

    public System.Guid Id { get; set; }

    public FinancierDisplayModel Financier { get => financier; set => SetProperty(ref financier, value); }

    public CurrencyDisplayModel Currency { get => currency; set => SetProperty(ref currency, value); }

    public float Amount { get => amount; set => SetProperty(ref amount, value); }

    public CurrencyDisplayModel[] AvailableCurrencies { get; private set; }

    public void PopulateAvailableCurrencies(IEnumerable<CurrencyDisplayModel> items)
    {
        AvailableCurrencies = [.. items];

        if (currency == null) return;
        
        Currency = AvailableCurrencies.FirstOrDefault(item => item.Id == currency.Id);
    }
}
namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public class SimplfiedFinancialDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool hasAnyBankAgency;
    private bool hasAnyBankBrench;
    private bool hasAnyCurrency;
    private bool isModuleReady;

    public bool HasAnyBankAgency { get => hasAnyBankAgency; set => SetProperty(ref hasAnyBankAgency, value); }

    public bool HasAnyBankBrench { get => hasAnyBankBrench; set => SetProperty(ref hasAnyBankBrench, value); }

    public bool HasAnyCurrency { get => hasAnyCurrency; set => SetProperty(ref hasAnyCurrency, value); }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }
}
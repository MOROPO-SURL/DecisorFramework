namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public class SimplifiedCommercialDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool hasAnyLegalBusinessKind;
    private bool hasAnyNaturalBusinessKind;
    private bool hasAnyPaymentTerm;
    private bool isModuleReady;

    public bool HasAnyLegalBusinessKind { get => hasAnyLegalBusinessKind; set => SetProperty(ref hasAnyLegalBusinessKind, value); }

    public bool HasAnyNaturalBusinessKind { get => hasAnyNaturalBusinessKind; set => SetProperty(ref hasAnyNaturalBusinessKind, value); }

    public bool HasAnyPaymentTerm { get => hasAnyPaymentTerm; set => SetProperty(ref hasAnyPaymentTerm, value); }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }
}

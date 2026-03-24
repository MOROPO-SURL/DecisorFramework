namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public class SimplfiedGovernanceDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool hasAnyGroup;
    private bool hasAnyMeeting;
    private bool hasAnyAgreement;
    private bool isModuleReady;

    public bool HasAnyGroup { get => hasAnyGroup; set => SetProperty(ref hasAnyGroup, value); }

    public bool HasAnyMeeting { get => hasAnyMeeting; set => SetProperty(ref hasAnyMeeting, value); }

    public bool HasAnyAgreement { get => hasAnyAgreement; set => SetProperty(ref hasAnyAgreement, value); }

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }
}
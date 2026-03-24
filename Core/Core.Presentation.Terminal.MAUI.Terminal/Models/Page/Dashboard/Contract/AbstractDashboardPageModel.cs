namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Dashboard.Contract;

public abstract class AbstractDashboardPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
{
    private bool isModuleReady;

    public bool IsModuleReady { get => isModuleReady; set => SetProperty(ref isModuleReady, value); }
}

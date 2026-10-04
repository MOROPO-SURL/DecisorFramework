namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page;

public sealed class RecommendingDashboardPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private long reportCount;

    public long ReportCount { get => reportCount; set => SetProperty(ref reportCount, value); }

    public Microsoft.Maui.Controls.ImageSource[] Images { get; set; }
}

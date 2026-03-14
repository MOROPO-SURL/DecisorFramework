using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page;

public class ObjectiveSummaryPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    private View.ObjectiveSummaryViewModel objective;

    public View.ObjectiveSummaryViewModel Objective { get => objective; set => SetProperty(ref objective, value); }

    public System.Collections.ObjectModel.ObservableCollection<ObjectiveDisplayModel> AvaialbleObjetives { get; set; } = [];
}

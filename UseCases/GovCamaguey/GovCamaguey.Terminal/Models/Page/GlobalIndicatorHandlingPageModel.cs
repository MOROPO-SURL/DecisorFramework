using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page;

public class GlobalIndicatorHandlingPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
{
    public System.Collections.ObjectModel.ObservableCollection<GlobalIndicatorDisplayModel> Indicators { get; set; } = [];
}
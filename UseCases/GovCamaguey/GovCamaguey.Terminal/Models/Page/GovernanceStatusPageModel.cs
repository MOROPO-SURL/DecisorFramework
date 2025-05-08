using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page
{
    public class GovernanceStatusPageModel : Framework.Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private View.ObjectiveViewModel objective;

        public View.ObjectiveViewModel Objective { get => objective; set => SetProperty(ref objective, value); }

        public ObservableCollection<ObjectiveDisplayModel> AvaialbleObjetives { get; set; } = [];
    }
}

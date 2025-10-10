namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Pick
{
    public class VacantPickPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractListEntityPageModel<View.VacantPickOrganizationalUnityViewModel>
    {
        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.StaffDisplayModel> AvailableStaffs { get; set; } = [];
    }
}
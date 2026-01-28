namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Manage
{
    public class OcupationsManagePageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractManageEntityPageModel<Interop.API.Common.Models.Display.OcupationDisplayModel>
    {
        private View.OcupationsManageVacantViewModel rootChiefVacant;

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.StaffDisplayModel> AvailableStaffs { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<View.StaffWorkforceViewModel> AvailableStaffWorkforces { get; set; } = [];

        public View.OcupationsManageVacantViewModel RootChiefVacant { get => rootChiefVacant; set => SetProperty(ref rootChiefVacant, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.OcupationsManageOrganizationalUnityViewModel> OrganizationalUnities { get; set; } = [];
    }
}

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Pick;

public class VacantPickPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
{
    private View.TreeVacantPickOrganizationalStructuringUnitViewModel rootTreeVacantPickOrganizationalStructuringUnitViewModel;

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.StaffDisplayModel> AvailableStaffs { get; set; } = [];

    public View.TreeVacantPickOrganizationalStructuringUnitViewModel RootTreeVacantPickOrganizationalStructuringUnitViewModel { get => rootTreeVacantPickOrganizationalStructuringUnitViewModel; set => SetProperty(ref rootTreeVacantPickOrganizationalStructuringUnitViewModel, value); }
}
namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.View.EmployeeViewModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.View.EmployeeViewModel> Build(Models.View.EmployeeViewModel model, System.Action<Models.View.EmployeeViewModel, int?> delegationAction = null)
        {
            return new Pages.Detail.EmployeeDetailPage(model);
        }
    }
}
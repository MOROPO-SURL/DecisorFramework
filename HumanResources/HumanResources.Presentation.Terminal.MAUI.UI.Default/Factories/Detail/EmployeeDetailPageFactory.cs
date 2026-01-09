namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{

    public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.Page.Detail.EmployeeDetailPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.Page.Detail.EmployeeDetailPageModel> Build(Models.Page.Detail.EmployeeDetailPageModel model, System.Action<Models.Page.Detail.EmployeeDetailPageModel, int?> delegationAction = null)
        {
            return new Pages.Detail.EmployeeDetailPage(model);
        }
    }
}
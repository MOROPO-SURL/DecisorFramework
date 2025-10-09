namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{

    /* Cambio no fusionado mediante combinación del proyecto 'HumanResources.Presentation.Terminal.MAUI.UI.Default (net8.0-android)'
    Antes:
        public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.View.EmployeeDetailPageModel>
    Después:
        public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<EmployeeDetailPageModel>
    */
    public class EmployeeDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.Page.Detail.EmployeeDetailPageModel>
    {

/* Cambio no fusionado mediante combinación del proyecto 'HumanResources.Presentation.Terminal.MAUI.UI.Default (net8.0-android)'
Antes:
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.View.EmployeeDetailPageModel> Build(Models.View.EmployeeDetailPageModel model, System.Action<Models.View.EmployeeDetailPageModel, int?> delegationAction = null)
Después:
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<EmployeeDetailPageModel> Build(EmployeeDetailPageModel model, System.Action<EmployeeDetailPageModel, int?> delegationAction = null)
*/
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.Page.Detail.EmployeeDetailPageModel> Build(Models.Page.Detail.EmployeeDetailPageModel model, System.Action<Models.Page.Detail.EmployeeDetailPageModel, int?> delegationAction = null)
        {
            return new Pages.Detail.EmployeeDetailPage(model);
        }
    }
}